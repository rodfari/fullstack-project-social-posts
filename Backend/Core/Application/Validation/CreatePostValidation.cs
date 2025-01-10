
using Core.Application.Requests;
using Core.Domain.Contracts;
using FluentValidation;

namespace Core.Application.Validation;

public class CreatePostRequestValidation: AbstractValidator<CreatePostRequest>
{
    
    public CreatePostRequestValidation(IPostRepository postRepository)
    {
        // 1. Validate the content length
        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Post content is required.")
            .MaximumLength(777)
            .WithMessage("Post content must be between 1 and 777 characters."); 
        
        // 2. Check the daily post limit
        var date = DateTime.UtcNow.Date;
        RuleFor(x => x.UserId)
            .MustAsync(async (userId, cancellation) => 
            {
                var postCount =  await postRepository
                .GetAllAsync(x => x.UserId == userId && x.CreatedAt.Date == date);
                return postCount.Count() < 5;
            })
            .WithMessage("You have reached the daily post limit.");
    }
}