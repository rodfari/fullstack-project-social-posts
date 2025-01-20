using Core.Domain.Contracts;
using Core.Domain.Enums;
using FluentValidation;

namespace Core.Application.Feature.Posts.Commands.CreatePosts;
public class CreatePostCommandValidator: AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator(IPostsRepository postsRepository)
    {
        // 1. Validate the content length
        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Post content is required.")
            .WithErrorCode(Enum.GetName(ErrorCodes.CONTENT_REQUIRED))
            .MaximumLength(777)
            .WithErrorCode(Enum.GetName(ErrorCodes.CONTENT_LENGTH))
            .WithMessage("Post content must be between 1 and 777 characters.")
            .When(x => !x.IsRepost == true); 
        
        // 2. Check the daily post limit
        var date = DateTime.UtcNow.Date;
        RuleFor(x => x.UserId)
            .MustAsync(async (userId, cancellation) => 
            {
                var postCount =  await postsRepository
                .GetAllAsync(x => x.UserId == userId && x.CreatedAt.Date == date);
                return postCount.Count() < 5;
            })
            .WithMessage("You have reached your 5 post limit per day.")
            .WithErrorCode(Enum.GetName(ErrorCodes.POST_LIMIT_EXCEEDED));

        // 3. Check if the AuthorId is not empty when reposting
        RuleFor(x => x.AuthorId)
            .NotEmpty()
            .WithMessage("AuthorId is required for reposting.")
            .WithErrorCode(Enum.GetName(ErrorCodes.AUTHOR_ID_REQUIRED))
            .When(x => x.IsRepost == true);

        // 4. Check if the OriginalPostId is not empty when reposting
        RuleFor(x => x.OriginalPostId)
            .NotEmpty()
            .WithMessage("OriginalPostId is required for reposting.")
            .WithErrorCode(Enum.GetName(ErrorCodes.ORIGINAL_POST_ID_REQUIRED))
            .When(x => x.IsRepost == true);

        //5. Check if the UserId has already reposted the post
        RuleFor(x => new { x.UserId, x.OriginalPostId })
            .MustAsync(async (x, cancellation) => 
            {
                var repost = await postsRepository
                .GetAllAsync(
                    p => p.UserId == x.UserId 
                    && p.OriginalPostId == x.OriginalPostId
                    && p.IsRepost == true,
                    1,  15, "");  
                return repost.Count() == 0;
            })
            .WithMessage("You have already reposted this post.")
            .WithErrorCode(Enum.GetName(ErrorCodes.REPOST_LIMIT_EXCEEDED))
            .When(x => x.IsRepost == true);

       


    }
}