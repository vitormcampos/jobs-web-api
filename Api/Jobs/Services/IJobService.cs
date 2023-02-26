using Jobs.Api.Common.Dto;
using Jobs.Api.Jobs.Dtos;
using Jobs.Core.Models;
using Jobs.Core.Repositories;

namespace Jobs.Api.Jobs.Services;

public interface IJobService
{
    ICollection<JobResponseDto> FindAll();
    PagedResponse<JobResponseDto> FindAll(int page, int size);
    JobDetailResponseDto FindById(int id);
    JobDetailResponseDto Create(JobRequestDto job);
    JobDetailResponseDto UpdateById(int id, JobRequestDto job);
    void DeleteById(int id);
}