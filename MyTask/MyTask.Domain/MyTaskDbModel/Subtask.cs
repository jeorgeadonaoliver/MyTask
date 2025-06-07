namespace MyTask.Api.Client.MyTaskDbModel;

public partial class Subtask
{
    public Guid SubtaskId { get; set; }

    public Guid ParentTaskId { get; set; }

    public string Title { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int Position { get; set; }

    public virtual Tasks ParentTask { get; set; } = null!;
}
