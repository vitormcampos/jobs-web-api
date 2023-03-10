namespace Jobs.Api.Auth.Dtos;

public class RegisterResponseDto
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
}