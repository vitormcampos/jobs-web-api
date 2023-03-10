using AutoMapper;
using Jobs.Api.Users.Dtos;
using Jobs.Core.Exceptions;
using Jobs.Core.Repositories.Users;
using Microsoft.AspNetCore.Identity;

namespace Jobs.Api.Users.Services;

class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> FindById(string id)
    {
        var user = await _userRepository.FindById(id);
        if (user is null) throw new RecordNotFoudException();
        var userDto = _mapper.Map<IdentityUser, UserResponseDto>(user);
        return userDto;
    }

    public async Task<ICollection<UserResponseDto>> FindAll()
    {
        var users = await _userRepository.FindAll();
        var usersDto = _mapper.Map<ICollection<IdentityUser>, ICollection<UserResponseDto>>(users);
        return usersDto;
    }

    public async Task<UserResponseDto> Create(UserRequestDto user)
    {
        var mappedUser = _mapper.Map<UserRequestDto, IdentityUser>(user);
        var resultUser = await _userRepository.Create(mappedUser, user.Senha);
        if (resultUser is null) throw new RecordNotFoudException();
        return _mapper.Map<IdentityUser, UserResponseDto>(resultUser);
    }

    public async Task<UserResponseDto> Update(string id, UserRequestDto body)
    {
        var user = await _userRepository.FindById(id);
        if(user is null) throw new RecordNotFoudException();

        user.Email = body.Email;
        user.UserName = body.UserName;
        user.PhoneNumber = body.Telefone;
        
        var resultUser = await _userRepository.Update(user);
        return _mapper.Map<IdentityUser, UserResponseDto>(resultUser);
    }

    public async Task DeleteById(string id)
    {
        var userExists = await _userRepository.ExistsById(id);
        if(!userExists) throw new RecordNotFoudException();

        await _userRepository.DeleteById(id);
    }
}