using AutoMapper;
using Jobs.Api.Users.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Jobs.Api.Users.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserRequestDto, IdentityUser>()
            .ForMember(
                dest => dest.PhoneNumber,
                opt =>
                    opt.MapFrom(
                        source =>
                            source.Telefone
                    )
            )
            .ForMember(
                dest => dest.PasswordHash,
                opt => opt.Ignore()
            );
        
        CreateMap<IdentityUser, UserRequestDto>()
            .ForMember(
                dest => dest.Telefone,
                opt =>
                    opt.MapFrom(
                        source =>
                            source.PhoneNumber
                    )
            )
            .ForMember(
                dest => dest.Senha,
                opt => opt.Ignore()
            );
        
        CreateMap<IdentityUser, UserResponseDto>()
            .ForMember(
                dest => dest.Telefone,
                opt =>
                    opt.MapFrom(
                        source =>
                            source.PhoneNumber
                    )
            )
            .ReverseMap();
    }
}