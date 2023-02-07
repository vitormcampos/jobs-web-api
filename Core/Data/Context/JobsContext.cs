using Jobs.Core.Data.EntityConfigs;
using Jobs.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Core.Data.Context;

public class JobsContext : DbContext
{
    public DbSet<Job> Jobs => Set<Job>();

    public JobsContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new JobEntityConfig());
    }
}