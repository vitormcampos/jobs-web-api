namespace Jobs.Api.Auth.Dtos;

public class LoginRequestDto
{
    public string Login { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
}