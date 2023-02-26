using Jobs.Api.Common.Dto;
using Jobs.Core.Data.Context;
using Jobs.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Core.Repositories.Jobs;

public class JobRepository : IJobRepository
{
    private readonly JobsContext _jobsContext;

    public JobRepository(JobsContext jobsContext)
    {
        _jobsContext = jobsContext;
    }

    public bool ExistsById(int id)
    {
        return _jobsContext.Jobs
            .AsNoTracking()
            .Any(j => j.Id == id);
    }

    public Job? FindById(int id)
    {
        return _jobsContext.Jobs
            .AsNoTracking()
            .FirstOrDefault(j =>
                j.Id == id
            );
    }

    public ICollection<Job> FindAll()
    {
        return _jobsContext.Jobs.AsNoTracking().ToList();
    }

    public Job Create(Job model)
    {
        _jobsContext.Jobs.Add(model);
        _jobsContext.SaveChanges();
        return model;
    }

    public Job Update(Job model)
    {
        _jobsContext.Jobs.Update(model);
        _jobsContext.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var job = _jobsContext.Jobs
            .AsNoTracking()
            .FirstOrDefault(j =>
                j.Id == id
            );
        if (job is not null)
        {
            _jobsContext.Jobs.Remove(job);
            _jobsContext.SaveChanges();
        }
    }

    public PagedResult<Job> FindAll(PaginationOptions options)
    {
        var totalElements = _jobsContext.Jobs.Count();
        var items = _jobsContext.Jobs
            .Skip(options.PageNumber - 1 * options.PageSize)
            .Take(options.PageSize)
            .ToList();

        return new PagedResult<Job>(
            items,
            options.PageNumber,
            options.PageSize,
            totalElements
        );
    }
}