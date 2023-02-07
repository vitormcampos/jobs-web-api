using Jobs.Api.Jobs.Dtos;
using Jobs.Core.Models;

namespace Jobs.Api.Jobs.Services;

public interface IJobService
{
    IEnumerable<Job> FindAll();
    Job FindById(int id);
    Job Create(JobRequestDto job);
    Job UpdateById(int id, JobRequestDto job);
    void DeleteById(int id);
}