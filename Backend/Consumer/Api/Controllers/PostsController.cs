using Microsoft.AspNetCore.Mvc;
using MediatR;
using Core.Application.Feature.Posts.Queries;
using Core.Application.Feature.Posts.Commands.CreatePosts;
using Core.Application.Reponses;
using Core.Application.Reponses.PostsResponses;

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
    public async Task<IActionResult> GetPosts([FromQuery] string? keyword, string? sort)
    {
        var result = await _mediator.Send(new GetAllPostsQuery { Keyword = keyword, Sort = sort });
        return Ok(result.Data);
    }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetPost(int id)
    // {
    //     var result = await _postHandler.GetPost(id);
    //     return Ok(result);
    // }

    // [HttpPost("repost")]
    // public async Task<IActionResult> CreateRepost([FromBody] CreateRepostRequest request)
    // {
    //     var result = await _postHandler.CreateRepost(request);
    //     return Ok(result);
    // }


    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand request)
    {
        ResponseBase<CreatePostResponse> data = await _mediator.Send(request);
        
        if(data.Success)
            return CreatedAtAction(nameof(GetPosts), data.Data.PostId);

        return BadRequest(data.Errors);
    }

}