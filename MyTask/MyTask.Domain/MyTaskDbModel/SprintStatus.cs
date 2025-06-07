namespace MyTask.Api.Client.MyTaskDbModel;

public partial class SprintStatus
{
    public Guid StatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();
}
