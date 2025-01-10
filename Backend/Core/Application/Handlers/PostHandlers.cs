using Application.Reponses.PostsResponses;
using Application.Requests;
using Core.Application.Contracts;
using Core.Application.Dtos;
using Core.Application.Reponses;
using Core.Application.Requests;
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
        await ExecuteAsync(request);
        return new PostDto();

    }

    public async Task<ResponseBase<PostDto>> CreateRepost(CreateRepostRequest request)
    {
        var originalPost = await _postRepository.GetByIdAsync(request.IdOriginalPost);
        var post = new Post
        {
            UserId = request.UserId,
            Content = originalPost.Content,
            OriginalPostId = originalPost.Id,
            IsRepost = true
        };
        var respost = await _postRepository.AddAsync(post);
        return new ResponseBase<PostDto>
        {
            Success = true,
            Data = new PostDto
            {
                //Username = respost.User.Username,
                PostId = respost.Id,
                Content = respost.Content
            }
        };

    }

    public async Task ExecuteAsync(CreatePostRequest request)
    {
        // 1. Validate the content length
        if (string.IsNullOrWhiteSpace(request.Content) || request.Content.Length > 777)
        {
            throw new ArgumentException("Post content must be between 1 and 777 characters.");
        }

        // 2. Check the daily post limit
        var today = DateTime.UtcNow.Date;

        // var dailyLimit = await _dailyPostLimitRepository.FindAsync(
        //     d => d.Id == request.UserId && d.CreatedAt == today
        // );

        // int postsToday = dailyLimit.FirstOrDefault()?.PostCount ?? 0;

        // if (postsToday >= 5)
        // {
        //     throw new InvalidOperationException("Daily post limit of 5 reached.");
        // }

        // 3. Create the post
        var newPost = new Post
        {
            UserId = request.UserId,
            Content = request.Content
        };

        await _postRepository.AddAsync(newPost);

        // 4. Update or create the DailyPostLimit
        //var userDailyLimit = dailyLimit.FirstOrDefault();

        // if (userDailyLimit == null)
        // {
        //     // Create a new daily limit entry
        //     var newDailyLimit = new DailyPostLimit
        //     {
        //         Id = request.UserId,
        //         CreatedAt = today,
        //         PostCount = 1
        //     };

        //     await _dailyPostLimitRepository.AddAsync(newDailyLimit);
        // }
        // else
        // {
        //     // Update the existing daily limit entry
        //     userDailyLimit.PostCount += 1;
        //     await _dailyPostLimitRepository.UpdateAsync(userDailyLimit);
        // }
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

        var posts = await _postRepository.GetPostsAndUserAsync();
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

        var posts = await _postRepository.GetPostsAndUserAsync();
        List<GetPostAndUserResponse> allPosts = new();

        posts.ForEach(p => allPosts.Add(new GetPostAndUserResponse
        {
            PostId = p.Id,
            OriginalPostId = p.OriginalPostId,
            Content = p.Content,
            UserName = p.User.Username,
            UserId = p.User.Id,
            CreatedAt = p.CreatedAt,
            IsRepost = p.IsRepost
        }));

        ResponseBase<List<GetPostAndUserResponse>> response = new()
        {
            Success = true,
            Data = allPosts
        };
        return response;

    }
}
