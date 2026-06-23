using Microsoft.AspNetCore.Mvc;
using HMS.Modules.Tenants.Domain;
using HMS.Modules.Tenants.Infrastructure;

namespace HMS.Modules.Tenants.Api;

[ApiController]
[Route("api/superadmin/tenants")]
public class TenantsController : ControllerBase
{
    private readonly TenantRepository _repository;
    private readonly TenantsDbContext _context;

    public TenantsController(TenantRepository repository, TenantsDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tenants = await _repository.GetAllAsync();
        return Ok(tenants);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTenantRequest request)
    {
        var tenant = new Tenant(Guid.NewGuid(), request.Name, request.Hostname, request.ConnectionString, request.KeycloakRealm);
        await _repository.AddAsync(tenant);
        await _context.SaveChangesAsync();
        return Ok(tenant);
    }
}

public record CreateTenantRequest(string Name, string Hostname, string ConnectionString, string KeycloakRealm);
