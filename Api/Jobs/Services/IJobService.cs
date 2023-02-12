using Jobs.Api.Jobs.Dtos;
using Jobs.Core.Models;

namespace Jobs.Api.Jobs.Services;

public interface IJobService
{
    ICollection<JobResponseDto> FindAll();
    JobDetailResponseDto FindById(int id);
    JobDetailResponseDto Create(JobRequestDto job);
    JobDetailResponseDto UpdateById(int id, JobRequestDto job);
    void DeleteById(int id);
}