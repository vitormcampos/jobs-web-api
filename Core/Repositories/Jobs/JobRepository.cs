using Jobs.Api.Common.Dto;
using Jobs.Core.Data.Context;
using Jobs.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Core.Repositories.Jobs;

public class JobRepository : IJobRepository
{
    private readonly JobsContext _jobsContext;

    public JobRepository(JobsContext jobsContext)
    {
        _jobsContext = jobsContext;
    }

    public async Task<bool> ExistsById(int id)
    {
        return await _jobsContext.Jobs
            .AsNoTracking()
            .AnyAsync(j => j.Id == id);
    }

    public async Task<Job?> FindById(int id)
    {
        return await _jobsContext.Jobs
            .AsNoTracking()
            .FirstOrDefaultAsync(j =>
                j.Id == id
            );
    }

    public async Task<ICollection<Job>> FindAll()
    {
        return await _jobsContext.Jobs.AsNoTracking().ToListAsync();
    }

    public async Task<Job> Create(Job model)
    {
        await _jobsContext.Jobs.AddAsync(model);
        await _jobsContext.SaveChangesAsync();
        return model;
    }

    public Task<Job> Update(Job model)
    {
        _jobsContext.Jobs.Update(model);
        _jobsContext.SaveChanges();
        return Task.FromResult(model);
    }

    public async Task DeleteById(int id)
    {
        var job = await _jobsContext.Jobs
            .AsNoTracking()
            .FirstOrDefaultAsync(j =>
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