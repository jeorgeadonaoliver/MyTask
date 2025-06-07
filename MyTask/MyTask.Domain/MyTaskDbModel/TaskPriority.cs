namespace MyTask.Api.Client.MyTaskDbModel;

public partial class TaskPriority
{
    public Guid PriorityId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
