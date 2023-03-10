using Jobs.Api.Users.Dtos;
using Jobs.Api.Users.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.Api.Users.Controllers;

[ApiController]
[Route("api/users")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<ActionResult> FindAll()
    {
        return Ok(await _userService.FindAll());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> FindById(string id)
    {
        return Ok(await _userService.FindById(id));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] string id, [FromBody] UserRequestDto user)
    {
        return Ok(await _userService.Update(id, user));
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteById([FromRoute] string id)
    {
        await _userService.DeleteById(id);
        return NoContent();
    }
}