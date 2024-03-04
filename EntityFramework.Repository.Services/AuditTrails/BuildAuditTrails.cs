using System.Security.Principal;
using EntityFramework.Repository.Services.AuditTrails.Options;
using EntityFramework.Repository.Services.AuditTrails.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFramework.Repository.Services.AuditTrails;

public static class AuditTrailsServiceExtensions
{
    public static IServiceCollection AddAuditTrails(this IServiceCollection services,
        Action<AuditTrailServiceOption> value = null)
    {
        if (value != null)
            services.AddScoped(provider =>
            {
                var option = new AuditTrailServiceOption();
                value(option);
                var service = new AuditTrailService();
                var principal = provider.GetService<IPrincipal>();
                service.AddAuditingMethod(option.Method, principal);
                return service;
            });

        return services;
    }
}