using Jobs.Core.Data.EntityConfigs;
using Jobs.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Core.Data.Context;

public class JobsContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Job> Jobs => Set<Job>();

    public JobsContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new JobEntityConfig());

        modelBuilder.Entity<IdentityUser>(entity => { entity.ToTable(name: "user"); });
        modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "role"); });
        modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("user_roles"); });
        modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("user_claims"); });
        modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("user_logins"); });
        modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("role_claims"); });
        modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("user_tokens"); });
    }
}