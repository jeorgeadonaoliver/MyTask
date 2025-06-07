namespace MyTask.Api.Client.MyTaskDbModel;

public partial class Project
{
    public Guid ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Guid OwnerId { get; set; }

    public Guid StatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();

    public virtual ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();

    public virtual ProjectStatus Status { get; set; } = null!;

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public virtual ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();
}
