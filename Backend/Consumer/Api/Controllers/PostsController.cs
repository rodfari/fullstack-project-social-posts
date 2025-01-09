using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Core.Application.Contracts;
using Core.Application.Requests;

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