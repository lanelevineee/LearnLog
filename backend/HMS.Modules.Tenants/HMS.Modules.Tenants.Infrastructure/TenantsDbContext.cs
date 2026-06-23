using Microsoft.EntityFrameworkCore;
using HMS.Modules.Tenants.Domain;

namespace HMS.Modules.Tenants.Infrastructure;

public class TenantsDbContext : DbContext
{
    public TenantsDbContext(DbContextOptions<TenantsDbContext> options) : base(options) { }

    public DbSet<Tenant> Tenants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tenant>().HasKey(t => t.Id);
        modelBuilder.Entity<Tenant>().HasIndex(t => t.Hostname).IsUnique();
        base.OnModelCreating(modelBuilder);
    }
}
