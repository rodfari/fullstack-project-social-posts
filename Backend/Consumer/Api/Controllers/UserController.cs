using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator _mediator)
    {
        _mediator = _mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        
        //TODO - Implement the logic to get all users
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        //TODO - Implement the logic to get user by id
        return Ok();
    }
}