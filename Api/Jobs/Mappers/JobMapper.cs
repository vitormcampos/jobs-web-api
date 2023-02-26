using AutoMapper;
using Jobs.Api.Common.Dto;
using Jobs.Api.Jobs.Dtos;
using Jobs.Core.Models;
using Jobs.Core.Repositories;

namespace Jobs.Api.Jobs.Mappers;

public class JobMapper : Profile
{
    public JobMapper()
    {
        CreateMap<JobRequestDto, Job>()
            .ForMember(
                dest => dest.Requirements,
                opt =>
                    opt.MapFrom(
                        source =>
                            string.Join(";", source.Requirements)
                    )
            );

        CreateMap<Job, JobResponseDto>()
            .ForMember(
                dest => dest.Requirements,
                opt =>
                    opt.MapFrom(
                        source =>
                            source.Requirements
                                .Split(";", StringSplitOptions.None)
                                .ToList()
                    )
            );

        CreateMap<JobDetailResponseDto, Job>()
            .ForMember(
                dest => dest.Requirements,
                opt =>
                    opt.MapFrom(
                        source =>
                            string.Join(";", source.Requirements)
                    )
            );

        CreateMap<Job, JobDetailResponseDto>()
            .ForMember(
                dest => dest.Requirements,
                opt =>
                    opt.MapFrom(
                        source =>
                            source.Requirements
                                .Split(";", StringSplitOptions.None)
                                .ToList()
                    )
            );
        
        CreateMap<PagedResponse<JobResponseDto>, PagedResult<Job>>()
            .ReverseMap();
    }
}