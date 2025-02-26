using Microsoft.AspNetCore.Mvc;
using MediatR;
using Core.Application.Feature.Posts.Queries;
using Core.Application.Feature.Posts.Commands.CreatePosts;
using Core.Application.Feature.Posts.Queries.GetPorstById;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IMediator _mediator;
    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts([FromQuery] int page, int pageSize, string? keyword, string? sort)
    {
        var result = await _mediator.Send(new GetAllPostsQuery { 
            Page = page,
            PageSize = pageSize,
            Keyword = keyword, 
            Sort = sort });
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> GetPost(int id)
    {
        var result = await _mediator.Send(new GetPostByIdQuery { Id = id });
        if(result.Success)
            return Ok(result.Data);
        return NotFound(result.Errors);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand request)
    {
        var response = await _mediator.Send(request);
        return  Ok(response);
    }

    [HttpPost("repost")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateRepost([FromBody] CreatePostCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

}