using Application.Reponses.PostsResponses;
using Core.Application.Requests;
using Core.Application.Validation;
using Core.Application.Contracts;
using Core.Application.Dtos;
using Core.Application.Reponses;
using Core.Domain.Contracts;
using Core.Domain.Entities;

namespace Core.Application.Handlers;

public class PostHandlers : IPostHandler
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public PostHandlers(
        IPostRepository postRepository,
        IUserRepository userRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task<PostDto> CreatePost(CreatePostRequest request)
    {
        var validator = new CreatePostRequestValidation(_postRepository);
        var validation = await validator.ValidateAsync(request);    

        if (validation.IsValid == false)
        {
            throw new ArgumentException(validation.Errors[0].ErrorMessage);
        }

        var newPost = new Post
        {
            UserId = request.UserId,
            Content = request.Content
        };

        await _postRepository.AddAsync(newPost);
        return new PostDto();
    }

    public async Task<ResponseBase<PostDto>> CreateRepost(CreateRepostRequest request)
    {
        var originalPost = await _postRepository.GetPostsAndUserByPostIdAsync(request.IdOriginalPost);
        var post = new Post
        {
            UserId = request.UserId,
            Content = originalPost.Content,
            OriginalPostId = originalPost.Id,
            Author = originalPost.User.Username,
            IdAuthor = originalPost.UserId,
            IsRepost = true
        };
        var respost = await _postRepository.AddAsync(post);
        return new ResponseBase<PostDto>
        {
            Success = true,
            Data = new PostDto
            {
                Username = respost.User.Username,
                PostId = respost.Id,
                Content = respost.Content
            }
        };

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

    public async Task<ResponseBase<List<GetPostAndUserResponse>>> GetPostsAndUsersAsync()
    {
        List<PostDto> postDtos = new();

        var posts = await _postRepository.GetAllPostsAndUserAsync();
        List<GetPostAndUserResponse> allPosts = new();

        posts.ForEach(p => allPosts.Add(new GetPostAndUserResponse
        {
            PostId = p.Id,
            OriginalPostId = p.OriginalPostId,
            Content = p.Content,
            UserName = p.User.Username,
            UserId = p.User.Id,
            CreatedAt = p.CreatedAt,
            IsRepost = p.IsRepost,
            Author = p.Author
        }));

        ResponseBase<List<GetPostAndUserResponse>> response = new()
        {
            Success = true,
            Data = allPosts
        };
        return response;

    }
}
