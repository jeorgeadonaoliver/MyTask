namespace MyTask.Api.Client.MyTaskDbModel;

public partial class Tag
{
    public Guid TagId { get; set; }

    public Guid ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
