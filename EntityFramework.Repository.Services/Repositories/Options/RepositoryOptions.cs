using EntityFramework.Repository.Services.AuditTrails.Options;

namespace EntityFramework.Repository.Services.Repositories.Options;

public sealed class RepositoryOptions
{
    internal Action<AuditTrailServiceOption> AuditTrailServiceOption { get; set; }

    public RepositoryOptions UseAuditTrailOption(Action<AuditTrailServiceOption> value = null)
    {
        AuditTrailServiceOption = value ?? (_ => { });
        return this;
    }
}