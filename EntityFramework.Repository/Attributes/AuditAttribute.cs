namespace EntityFramework.Repository.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
public sealed class AuditTrailsAttribute : Attribute
{
    public bool Ignore { get; set; }
}