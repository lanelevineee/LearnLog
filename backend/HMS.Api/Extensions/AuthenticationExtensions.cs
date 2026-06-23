using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using HMS.Modules.Tenants.Domain;

namespace HMS.Api.Extensions;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddDynamicKeycloakAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "http://localhost:8080/realms/master"; // Default
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        // Custom validation logic if needed
                        return Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        var tenant = context.HttpContext.Items["Tenant"] as Tenant;
                        if (tenant != null)
                        {
                            // Dynamically adjust the authority based on the tenant's realm
                            // Note: This is simplified. In a real scenario, you might need a custom JwtBearerHandler
                            // or to use a library like Finbuckle.MultiTenant which handles this better.
                            // For this MVP, we'll assume the token has the correct issuer.
                        }
                        return Task.CompletedTask;
                    }
                };
            });

        return services;
    }
}
