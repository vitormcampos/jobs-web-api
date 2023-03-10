using AutoMapper;
using Jobs.Api.Auth.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Jobs.Api.Auth.Mappers;

public class AuthMapper : Profile
{
    public AuthMapper()
    {
        CreateMap<RegisterRequestDto, IdentityUser>()
            .ForMember(u => u.PhoneNumber,
                opt =>
                    opt.MapFrom(r => r.Telefone)
            )
            .ReverseMap();
        
        CreateMap<RegisterRequestDto, RegisterResponseDto>().ReverseMap();
        
        CreateMap<string, LoginResponseDto>()
            .ForMember(l => l.Token,
                opt =>
                    opt.MapFrom(s => s)
            );
    }
}