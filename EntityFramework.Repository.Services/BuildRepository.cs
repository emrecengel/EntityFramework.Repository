using EntityFramework.Repository.Services.AuditTrails;
using EntityFramework.Repository.Services.Repositories;
using EntityFramework.Repository.Services.Repositories.Options;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFramework.Repository.Services;

public static class BuildRepository
{
    public static IServiceCollection AddRepository(this IServiceCollection services,
        Action<RepositoryOptions> value = null)
    {
        var repositoryOptions = new RepositoryOptions();
        value?.Invoke(repositoryOptions);

        services.AddAuditTrails(repositoryOptions?.AuditTrailServiceOption);
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        return services;
    }
}