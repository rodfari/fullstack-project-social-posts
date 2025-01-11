using System.Linq.Expressions;
using Core.Application.Dtos;
using Core.Application.Feature.Posts.Queries;
using Core.Application.Reponses;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using MediatR;

namespace Application.Feature.Posts.Queries;
public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, TResponse<List<PostDto>>>
{
    private readonly IPostRepository _postRepository;
    public GetAllPostsQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public async Task<TResponse<List<PostDto>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Post, bool>> predicate = null;
        if (!string.IsNullOrEmpty(request.Keyword))
        {
            predicate = x => x.Content.Contains(request.Keyword);
        }


        var posts = await _postRepository.GetAllPostsAndUserAsync(predicate, request.Sort);
        List<PostDto> allPosts = new();

        posts.ForEach(p => allPosts.Add(new PostDto
        {
            PostId = p.Id,
            Content = p.Content,
            CreatedAt = p.CreatedAt,
        }));

        TResponse<List<PostDto>> response = new()
        {
            Success = true,
            Data = allPosts
        };
        return response;

    }
}