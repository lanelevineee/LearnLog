namespace HMS.Shared.Interfaces;

public interface ITenantService
{
    string? GetCurrentTenantId();
    string? GetCurrentTenantHostname();
}
