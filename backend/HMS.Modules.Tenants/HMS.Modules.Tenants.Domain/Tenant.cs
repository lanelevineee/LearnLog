using HMS.Shared.Domain;

namespace HMS.Modules.Tenants.Domain;

public class Tenant : AggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string Hostname { get; private set; }
    public string ConnectionString { get; private set; }
    public string KeycloakRealm { get; private set; }
    public bool IsActive { get; private set; }

    private Tenant() { }

    public Tenant(Guid id, string name, string hostname, string connectionString, string keycloakRealm) : base(id)
    {
        Name = name;
        Hostname = hostname;
        ConnectionString = connectionString;
        KeycloakRealm = keycloakRealm;
        IsActive = true;
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}
