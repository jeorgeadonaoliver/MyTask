namespace MyTask.Api.Client.MyTaskDbModel;

public partial class TaskAssignment
{
    public Guid TaskId { get; set; }

    public Guid UserId { get; set; }

    public DateTime AssignedAt { get; set; }

    public virtual Tasks Task { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
