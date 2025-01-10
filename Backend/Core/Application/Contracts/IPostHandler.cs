using Core.Application.Dtos;
using Core.Application.Reponses;
using Core.Application.Reponses.PostsResponses;
using Core.Application.Requests;

namespace Core.Application.Contracts;

public interface IPostHandler
{
    // Task<ResponseBase<List<GetPostAndUserResponse>>> SearchKeywordAsync(string keyword);
    Task<ResponseBase<List<GetAllPostAndUserResponse>>> GetAllPostsAndUsersAsync(GetAllPostAndUserRequest request);
    Task<ResponseBase<PostDto>> CreateRepost(CreateRepostRequest request);
    Task<ResponseBase<CreatePostResponse>> CreatePostAsync(CreatePostRequest request);
    Task<PostDto> GetPost(int id);
    Task<ResponseBase<List<GetSortedPostResponse>>> GetSortedPosts(string sort);
}