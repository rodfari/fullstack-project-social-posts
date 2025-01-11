using Core.Application.Requests;
using Core.Application.Validation;
using Core.Application.Contracts;
using Core.Application.Dtos;
using Core.Application.Reponses;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Core.Application.Reponses.PostsResponses;
using System.Linq.Expressions;

namespace Core.Application.Handlers;

public class PostHandlers : IPostHandler
{
    private readonly IPostRepository _postRepository;

    public PostHandlers(
        IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<ResponseBase<CreatePostResponse>> CreatePostAsync(CreatePostRequest request)
    {
        var validator = new CreatePostRequestValidation(_postRepository);
        var validation = await validator.ValidateAsync(request);

        if (validation.IsValid == false)
        {
            List<Error> errors = [];

            validation.Errors.ToList().ForEach(x => errors.Add(new Error
            {
                Code = x.ErrorCode,
                Message = x.ErrorMessage
            }));
            return new ResponseBase<CreatePostResponse>
            {
                Success = false,
                Errors = errors
            };
        }

        var newPost = new Post
        {
            UserId = request.UserId,
            Content = request.Content
        };

        await _postRepository.AddAsync(newPost);
        return new ResponseBase<CreatePostResponse>
        {
            Success = true,
            Data = new CreatePostResponse
            {
                PostId = newPost.Id,
                UserId = newPost.UserId,
                Content = newPost.Content,
                // Author = newPost.Author,
                // IdAuthor = newPost.IdAuthor,
                // IsRepost = newPost.IsRepost,
                // OriginalPostId = newPost.OriginalPostId,
            }
        };
    }

    public async Task<ResponseBase<PostDto>> CreateRepost(CreateRepostRequest request)
    {
        var originalPost = await _postRepository.GetPostAndUserByPostIdAsync(request.IdOriginalPost);
        // originalPost.RepostCount++;
        var post = new Post
        {
            UserId = request.UserId,
            Content = originalPost.Content,
            // OriginalPostId = originalPost.Id,
            // Author = originalPost.User.Username,
            // IdAuthor = originalPost.UserId,
            // IsRepost = true
        };
        var respost = await _postRepository.AddAsync(post);
        await _postRepository.UpdateAsync(originalPost);
        return new ResponseBase<PostDto>
        {
            Success = true,
            Data = new PostDto
            {
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


    public async Task<ResponseBase<List<GetAllPostAndUserResponse>>> 
    GetAllPostsAndUsersAsync( GetAllPostAndUserRequest request)
    {
        Expression<Func<Post, bool>> predicate = null;
        if(!string.IsNullOrEmpty(request.Keyword)){
            predicate = x => x.Content.Contains(request.Keyword);
        }


        var posts = await _postRepository.GetAllPostsAndUserAsync(predicate, request.Sort);

        List<GetAllPostAndUserResponse> allPosts = new();

        posts.ForEach(p => allPosts.Add(new GetAllPostAndUserResponse
        {
            PostId = p.Id,
            Content = p.Content,
            UserName = p.User.Username,
            UserId = p.User.Id,
            CreatedAt = p.CreatedAt,
        }));

        ResponseBase<List<GetAllPostAndUserResponse>> response = new()
        {
            Success = true,
            Data = allPosts
        };
        return response;

    }
}
