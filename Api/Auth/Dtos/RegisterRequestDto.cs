namespace Jobs.Api.Auth.Dtos;

public class RegisterRequestDto
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}