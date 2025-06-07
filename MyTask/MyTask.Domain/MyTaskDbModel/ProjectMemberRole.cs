namespace MyTask.Api.Client.MyTaskDbModel;

public partial class ProjectMemberRole
{
    public Guid RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
}
