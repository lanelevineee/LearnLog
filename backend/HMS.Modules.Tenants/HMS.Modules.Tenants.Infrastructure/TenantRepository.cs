using Microsoft.EntityFrameworkCore;
using HMS.Modules.Tenants.Domain;
using HMS.Shared.Interfaces;

namespace HMS.Modules.Tenants.Infrastructure;

public class TenantRepository : IRepository<Tenant, Guid>
{
    private readonly TenantsDbContext _context;

    public TenantRepository(TenantsDbContext context)
    {
        _context = context;
    }

    public async Task<Tenant?> GetByIdAsync(Guid id)
    {
        return await _context.Tenants.FindAsync(id);
    }

    public async Task<IReadOnlyList<Tenant>> GetAllAsync()
    {
        return await _context.Tenants.ToListAsync();
    }

    public async Task AddAsync(Tenant entity)
    {
        await _context.Tenants.AddAsync(entity);
    }

    public async Task UpdateAsync(Tenant entity)
    {
        _context.Tenants.Update(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Tenant entity)
    {
        _context.Tenants.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task<Tenant?> GetByHostnameAsync(string hostname)
    {
        return await _context.Tenants.FirstOrDefaultAsync(t => t.Hostname == hostname);
    }
}
