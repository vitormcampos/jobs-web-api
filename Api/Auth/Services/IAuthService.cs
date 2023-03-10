using Jobs.Api.Auth.Dtos;
using Jobs.Api.Users.Dtos;

namespace Jobs.Api.Auth.Services;

public interface IAuthService
{
    Task<LoginResponseDto> Login(LoginRequestDto login);
    Task<RegisterResponseDto> Register(RegisterRequestDto register);
}