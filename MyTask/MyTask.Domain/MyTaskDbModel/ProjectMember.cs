namespace MyTask.Api.Client.MyTaskDbModel;

public partial class ProjectMember
{
    public Guid ProjectId { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public DateTime AddedAt { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ProjectMemberRole Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
