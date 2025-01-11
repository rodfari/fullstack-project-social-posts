using Core.Application.Reponses;
using Core.Application.Reponses.PostsResponses;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using MediatR;

namespace Core.Application.Feature.Posts.Commands.CreatePosts;
public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, TResponse<CreatePostResponse>>
{
    private readonly IPostRepository _postRepository;
    public CreatePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public async Task<TResponse<CreatePostResponse>> 
    Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreatePostCommandValidator(_postRepository);
        var validation = await validator.ValidateAsync(request);

        if (validation.IsValid == false)
        {
            List<Error> errors = [];

            validation.Errors.ToList().ForEach(x => errors.Add(new Error
            {
                Code = x.ErrorCode,
                Message = x.ErrorMessage
            }));
            return new TResponse<CreatePostResponse>
            {
                Success = false,
                Errors = errors
            };
        }


        var newPost = new Post
        {
            UserId = request.UserId,
            Content = request.Content
        };

        await _postRepository.AddAsync(newPost);
        return new TResponse<CreatePostResponse>
        {
            Success = true,
            Data = new CreatePostResponse
            {
                PostId = newPost.Id,
                UserId = newPost.UserId,
                Content = newPost.Content,
            }
        };
    }


}