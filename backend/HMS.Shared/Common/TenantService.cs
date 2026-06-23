using Microsoft.AspNetCore.Http;
using HMS.Shared.Interfaces;

namespace HMS.Shared.Common;

public class TenantService : ITenantService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TenantService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetCurrentTenantHostname()
    {
        return _httpContextAccessor.HttpContext?.Request.Host.Host;
    }

    public string? GetCurrentTenantId()
    {
        // This could be resolved from a custom header or the hostname
        return GetCurrentTenantHostname();
    }
}
