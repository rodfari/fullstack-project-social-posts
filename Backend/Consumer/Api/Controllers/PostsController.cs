using Microsoft.AspNetCore.Mvc;
using Core.Application.Requests;
using Core.Application.Contracts;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    public readonly IPostHandler _postHandler;
    private readonly ILogger<PostsController> _logger;
    public PostsController(IPostHandler postHandler, ILogger<PostsController> logger)
    {
        _postHandler = postHandler;
        _logger = logger;
    }

    [HttpGet("get-posts")]
    public async Task<IActionResult> GetPosts()
    {
        return Ok();
    }

    [HttpGet("get-post/{id}")]
    public async Task<IActionResult> GetPost(int id)
    {
        return Ok();
    }

    [HttpPost("create-post")]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
    {
        await _postHandler.CreatePost(request);
        return Ok();
    }

}