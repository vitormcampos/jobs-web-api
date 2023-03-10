using AutoMapper;
using FluentValidation;
using Jobs.Api.Auth.Dtos;
using Jobs.Api.Common.Services;
using Jobs.Api.Users.Dtos;
using Jobs.Api.Users.Services;
using Jobs.Core.Exceptions;
using Jobs.Core.Repositories.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Api.Auth.Services;

class AuthService : IAuthService
{
    private readonly IValidator<LoginRequestDto> _loginValidator;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AuthService(
        IValidator<LoginRequestDto> loginValidator,
        UserManager<IdentityUser> userManager,        
        ITokenService tokenService,
        IMapper mapper
    )
    {
        _loginValidator = loginValidator;
        _userManager = userManager;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto login)
    {
        await _loginValidator.ValidateAndThrowAsync(login);

        var user = await _userManager.FindByEmailAsync(login.Login);
        if (user is null) throw new LoginFailedException();

        var verifyPass = await _userManager.CheckPasswordAsync(user, login.Password);
        if (!verifyPass) throw new LoginFailedException();

        var token = _tokenService.GenerateToken(user);
        return _mapper.Map<string, LoginResponseDto>(token);
    }

    public async Task<RegisterResponseDto> Register(RegisterRequestDto register)
    {
        var identityUser = _mapper.Map<RegisterRequestDto, IdentityUser>(register);
        var result = await _userManager.CreateAsync(identityUser, register.Senha);
        if (!result.Succeeded) throw new RegisterFailedExeception(String.Join(',', result.Errors.Select(e => e.Description)));

        return _mapper.Map<RegisterRequestDto, RegisterResponseDto>(register);
    }
}