namespace MyTask.Api.Client.MyTaskDbModel;

public partial class AuditLog
{
    public long LogId { get; set; }

    public string Entity { get; set; } = null!;

    public Guid EntityId { get; set; }

    public string Action { get; set; } = null!;

    public Guid ChangedBy { get; set; }

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public DateTime At { get; set; }

    public virtual User ChangedByNavigation { get; set; } = null!;
}
