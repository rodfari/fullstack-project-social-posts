using Application.Reponses.PostsResponses;
using Core.Application.Dtos;
using Core.Application.Reponses;
using Core.Application.Requests;

namespace Core.Application.Contracts;

public interface IPostHandler
{
    Task<ResponseBase<List<GetPostAndUserResponse>>> GetPostsAndUsersAsync();
    Task<PostDto> CreatePost(CreatePostRequest request);
    Task<PostDto> GetPost(int id);
    Task<List<PostDto>> GetPosts();
}