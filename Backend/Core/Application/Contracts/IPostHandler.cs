using Application.Dtos;
using Core.Application.Requests;

namespace Backend.Core.Application.Contracts;

public interface IPostHandler
{
    Task<PostDto> CreatePost(CreatePostRequest request);
    Task<PostDto> GetPost(int id);
    Task<IEnumerable<PostDto>> GetPosts();
}