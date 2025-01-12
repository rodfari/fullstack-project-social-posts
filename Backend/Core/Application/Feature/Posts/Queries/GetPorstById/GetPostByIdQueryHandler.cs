
using Core.Application.Reponses;
using Core.Application.Reponses.PostsResponses;
using Core.Domain.Contracts;
using MediatR;

namespace Core.Application.Feature.Posts.Queries.GetPorstById;
public class GetPostByIdQueryHandler: IRequestHandler<GetPostByIdQuery, TResponse<GetPostByIdResponse>>
{
    private readonly IPostsRepository _postsRepository;
    public GetPostByIdQueryHandler(IPostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }
    public async Task<TResponse<GetPostByIdResponse>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _postsRepository.GetByIdAsync(request.PostId);

        if (post == null)
        {
            return new TResponse<GetPostByIdResponse>
            {
                Success = false,
                Errors = new List<Error>
                {
                    new Error
                    {
                        Code = "404",
                        Message = "Post not found"
                    }
                }
            };
        }

        return new TResponse<GetPostByIdResponse>
        {
            Success = true,
            Data = new GetPostByIdResponse
            {
                UserId = post.UserId,
                PostId = post.Id,
                Content = post.Content,
                UserName = post.User.Username,
                CreatedAt = post.CreatedAt
            }
        };
    }
}