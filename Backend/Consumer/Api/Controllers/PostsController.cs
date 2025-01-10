using Microsoft.AspNetCore.Mvc;
using Core.Application.Requests;
using Core.Application.Contracts;
using Application.Requests;

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

    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        var result = await _postHandler.GetPostsAndUsersAsync();
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(int id)
    {
        var result = await _postHandler.GetPost(id);
        return Ok(result);
    }

    [HttpGet("sort/{sort}")]
    public async Task<IActionResult> GetSortedPosts(string sort)
    {
        var result = await _postHandler.GetSortedPosts(sort);
        return Ok(result);
    }

    [HttpPost("search")]
    public async Task<IActionResult> Search([FromBody] SearchPostRequest request)
    {
        var result = await _postHandler.SearchKeywordAsync(request.KeyWord);
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