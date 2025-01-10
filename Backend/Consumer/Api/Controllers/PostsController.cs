using Microsoft.AspNetCore.Mvc;
using Core.Application.Requests;
using Core.Application.Contracts;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    public readonly IPostHandler _postHandler;
    public PostsController(IPostHandler postHandler, ILogger<PostsController> logger)
    {
        _postHandler = postHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts([FromQuery] string? keyword, string? sort)
    {
        var result = await _postHandler.GetAllPostsAndUsersAsync(
            new GetAllPostAndUserRequest
            {
                Keyword = keyword,
                Sort = sort
            }
        );
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(int id)
    {
        var result = await _postHandler.GetPost(id);
        return Ok(result);
    }

    [HttpPost("repost")]
    public async Task<IActionResult> CreateRepost([FromBody] CreateRepostRequest request)
    {
        var result = await _postHandler.CreateRepost(request);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
    {
        var data = await _postHandler.CreatePostAsync(request);
        return Ok(data);
    }

}