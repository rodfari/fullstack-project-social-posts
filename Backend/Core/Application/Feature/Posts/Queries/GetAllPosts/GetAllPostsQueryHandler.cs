using System.Linq.Expressions;
using System.Linq;
using Core.Application.Dtos;
using Core.Application.Feature.Posts.Queries;
using Core.Application.Reponses;
using Core.Domain.Contracts;
using MediatR;

namespace Application.Feature.Posts.Queries;

public delegate Task<TResponse<List<PostDto>>> GetAllPostsQueryDelegate(
    string Keyword,
    int Page,
    int PageSize,
    string Sort,
    bool Trending
);

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
            predicate = x => x.Content!.Contains(request.Keyword) && x.IsRepost == false;
        }


        var posts = await _postsRepository.GetAllAsync(
            predicate, 
            request.Page,
            request.PageSize,
            request.Sort
            );
        int total = await _postsRepository.CountAsync();
        
        List<PostDto> allPosts = [];

        posts?.ForEach(p => allPosts.Add(new PostDto
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
            Data = allPosts,
            Pagination = new Pagination
            {
                Page = request.Page,
                PageSize = request.PageSize,
                Total = total
            }
        };
        return response;
    }
}