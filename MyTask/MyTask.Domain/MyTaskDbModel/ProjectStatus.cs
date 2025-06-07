namespace MyTask.Api.Client.MyTaskDbModel;

public partial class ProjectStatus
{
    public Guid StatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
