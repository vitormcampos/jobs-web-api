using Jobs.Core.Models;

namespace Jobs.Core.Repositories.Jobs;

public interface IJobRepository : ICrudRepository<Job, int>, IPagedRepository<Job>
{
}