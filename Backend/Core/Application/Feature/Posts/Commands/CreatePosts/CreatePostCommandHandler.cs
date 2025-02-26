using AutoMapper;
using Core.Application.Reponses;
using Core.Application.Reponses.PostsResponses;
using Core.Domain.Contracts;
using MediatR;

namespace Core.Application.Feature.Posts.Commands.CreatePosts;
public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, TResponse<CreatePostResponse>>
{
    private readonly IPostsRepository _postsRepository;
    readonly IMapper _mapper;
    public CreatePostCommandHandler(IPostsRepository postsRepository, IMapper mapper)
    {
        _postsRepository = postsRepository;
        _mapper = mapper;
    }
    public async Task<TResponse<CreatePostResponse>>
    Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreatePostCommandValidator(_postsRepository);
        var validation = await validator.ValidateAsync(request);

        if (validation.IsValid == false)
        {
            List<Error> errors = [];

            validation.Errors.ToList().ForEach(x => errors.Add(new Error
            {
                Code = x.ErrorCode,
                Message = x.ErrorMessage
            }));
            return new TResponse<CreatePostResponse>()
            .SetIsSuccess(false)
            .SetErrors(errors);
        }

        if (request.IsRepost)
        {
            var originalPost = await _postsRepository.GetByIdAsync(request.OriginalPostId.GetValueOrDefault());
            originalPost.RepostCount = originalPost.RepostCount + 1;
            await _postsRepository.UpdateAsync(originalPost);
        }

        

        var newPost =  _mapper.Map<Domain.Entities.Posts>(request);

        await _postsRepository.AddAsync(newPost);

        return new TResponse<CreatePostResponse>()
        .SetIsSuccess(true)
        .SetData(new CreatePostResponse
        {
            PostId = newPost.Id,
            UserId = newPost.UserId,
            Content = newPost.Content,
        });
    }
}