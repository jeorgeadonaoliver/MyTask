namespace MyTask.Api.Client.MyTaskDbModel;

public partial class TaskList
{
    public Guid ListId { get; set; }

    public Guid ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public int Position { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
