using AutoMapper;
using Jobs.Api.Jobs.Dtos;
using Jobs.Core.Models;

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
                            string.Join(";", source.Requirements
                            )
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
    }
}