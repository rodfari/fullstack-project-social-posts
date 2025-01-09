using Core.Application.Contracts;
using Core.Application.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RepostController : ControllerBase
{
    public IRepostHandler _repostHandler { get; }
    public ILogger<RepostController> _logger { get; }
    public RepostController(IRepostHandler repostHandler, ILogger<RepostController> logger)
    {
        _logger = logger;
        _repostHandler = repostHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRepost([FromBody] RepostRequest request)
    {
        await _repostHandler.CreateRepost(request);
        return Ok();
    }
}