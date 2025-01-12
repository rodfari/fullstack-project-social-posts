using Core.Application.Requests;
using Core.Application.Validation;
using Core.Application.Dtos;
using Core.Application.Reponses;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Core.Application.Reponses.PostsResponses;
using System.Linq.Expressions;

namespace Core.Application.Handlers;

public class PostHandlers 
{
    private readonly IPostRepository _postRepository;

    public PostHandlers(
        IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostDto> GetPost(int id)
    {
        var posts = await _postRepository.GetByIdAsync(id);
        PostDto postDto = new()
        {
            PostId = posts.Id,
            Content = posts.Content
        };
        return postDto;
    }
    public async Task<List<PostDto>> GetPosts()
    {
        List<PostDto> postDtos = new();

        var posts = await _postRepository.GetAllPostsAndUserAsync();
        posts.ForEach(p => postDtos.Add(new PostDto
        {
            PostId = p.Id,
            Content = p.Content
        }));

        return postDtos;
    }


    public async Task<TResponse<List<GetAllPostsResponse>>> 
    GetAllPostsAndUsersAsync( GetAllPostAndUserRequest request)
    {
        Expression<Func<Post, bool>> predicate = null;
        if(!string.IsNullOrEmpty(request.Keyword)){
            predicate = x => x.Content.Contains(request.Keyword);
        }


        var posts = await _postRepository.GetAllPostsAndUserAsync(predicate, request.Sort);

        List<GetAllPostsResponse> allPosts = new();

        posts.ForEach(p => allPosts.Add(new GetAllPostsResponse
        {
            PostId = p.Id,
            Content = p.Content,
            UserName = p.User.Username,
            UserId = p.User.Id,
            CreatedAt = p.CreatedAt,
        }));

        TResponse<List<GetAllPostsResponse>> response = new()
        {
            Success = true,
            Data = allPosts
        };
        return response;

    }
}
