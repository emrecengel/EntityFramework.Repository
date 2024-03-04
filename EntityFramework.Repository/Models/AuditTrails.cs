namespace EntityFramework.Repository.Models;

public sealed class AuditTrail
{
    public string TableName { get; set; }
    public DateTime DateTime { get; set; }
    public string KeyValues { get; set; }
    public string OldValues { get; set; }
    public string NewValues { get; set; }
    public Guid? UserId { get; set; }
}