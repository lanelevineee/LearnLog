using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using HMS.Modules.Tenants.Infrastructure;
using HMS.Shared.Interfaces;
using Microsoft.AspNetCore.Http;

namespace HMS.Api.Middleware;

public class TenantResolverMiddleware
{
    private readonly RequestDelegate _next;

    public TenantResolverMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITenantService tenantService, TenantRepository tenantRepository)
    {
        var hostname = tenantService.GetCurrentTenantHostname();

        if (!string.IsNullOrEmpty(hostname) && hostname != "localhost")
        {
            var tenant = await tenantRepository.GetByHostnameAsync(hostname);
            if (tenant != null)
            {
                context.Items["Tenant"] = tenant;
            }
        }

        await _next(context);
    }
}
