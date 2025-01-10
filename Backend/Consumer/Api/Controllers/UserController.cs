using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserHandler _userHandler;
    public UserController(IUserHandler userHandler)
    {
        _userHandler = userHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUser()
    {
        var response = await _userHandler.GetAllUserAsync();
        return Ok(response.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var response = await _userHandler.GetUserByIdAsync(id);
        return Ok(response.Data);
    }
}