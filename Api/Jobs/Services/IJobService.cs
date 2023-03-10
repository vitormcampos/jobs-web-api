using Jobs.Api.Common.Dto;
using Jobs.Api.Jobs.Dtos;
using Jobs.Core.Models;
using Jobs.Core.Repositories;

namespace Jobs.Api.Jobs.Services;

public interface IJobService
{
    Task<ICollection<JobResponseDto>> FindAll();
    PagedResponse<JobResponseDto> FindAll(int page, int size);
    Task<JobDetailResponseDto> FindById(int id);
    Task<JobDetailResponseDto> Create(JobRequestDto job);
    Task<JobDetailResponseDto> UpdateById(int id, JobRequestDto job);
    Task DeleteById(int id);
}