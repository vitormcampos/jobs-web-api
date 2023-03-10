using Jobs.Api.Auth.Dtos;
using Jobs.Api.Auth.Services;
using Jobs.Api.Users.Dtos;
using Jobs.Api.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.Api.Auth.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register", Name = "register")]
    public async Task<IActionResult> Register(RegisterRequestDto register)
    {
        return Ok(await _authService.Register(register));
    }

    [HttpPost("login", Name = "login")]
    public async Task<IActionResult> Login(LoginRequestDto login)
    {
        return Ok(await _authService.Login(login));
    }
}