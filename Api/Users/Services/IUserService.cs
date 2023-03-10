using Jobs.Api.Users.Dtos;

namespace Jobs.Api.Users.Services;

public interface IUserService
{
    Task<UserResponseDto> FindById(string id);
    Task<ICollection<UserResponseDto>> FindAll();
    Task<UserResponseDto> Create(UserRequestDto user);
    Task<UserResponseDto> Update(string id, UserRequestDto body);
    Task DeleteById(string id);
}