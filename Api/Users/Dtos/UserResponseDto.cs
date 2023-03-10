using Jobs.Api.Common.Dto;

namespace Jobs.Api.Users.Dtos;

public class UserResponseDto : ResourceResponseDto
{
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
}