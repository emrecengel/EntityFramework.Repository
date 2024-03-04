using EntityFramework.Repository.Models;

namespace EntityFramework.Repository.Services.AuditTrails.Options;

public sealed class AuditTrailServiceOption
{
    internal Action<IReadOnlyList<AuditTrail>> Method { get; set; }

    public AuditTrailServiceOption HandleRecordAuditing(Action<IReadOnlyList<AuditTrail>> auditTrails)
    {
        Method = auditTrails;
        return this;
    }
}