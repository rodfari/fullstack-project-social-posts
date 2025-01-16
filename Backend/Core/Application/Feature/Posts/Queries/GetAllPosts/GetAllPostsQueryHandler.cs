using System.Linq.Expressions;
using Core.Application.Dtos;
using Core.Application.Feature.Posts.Queries;
using Core.Application.Reponses;
using Core.Domain.Contracts;
using MediatR;

namespace Application.Feature.Posts.Queries;
public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, TResponse<List<PostDto>>>
{
    private readonly IPostsRepository _postsRepository;
    public GetAllPostsQueryHandler(IPostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }
    public async Task<TResponse<List<PostDto>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Core.Domain.Entities.Posts, bool>>? predicate = null;

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            predicate = x => x.Content!.Contains(request.Keyword);
        }


        var posts = await _postsRepository.GetAllAsync(predicate, request.Sort, request.Trending);

        List<PostDto> allPosts = new();

        posts.ForEach(p => allPosts.Add(new PostDto
        {
            PostId = p.Id,
            Content = p.Content ?? p.Reposts?.Content,
            CreatedAt = p.CreatedAt,
            IsRepost = p.IsRepost,
            Username = p.User?.Username,
            UserId = p.UserId,
            Author = p.Author?.Username,

        }));

        TResponse<List<PostDto>> response = new()
        {
            Success = true,
            Data = allPosts
        };
        return response;

    }
}