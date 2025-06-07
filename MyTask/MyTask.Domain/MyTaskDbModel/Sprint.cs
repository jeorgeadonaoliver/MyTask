namespace MyTask.Api.Client.MyTaskDbModel;

public partial class Sprint
{
    public Guid SprintId { get; set; }

    public Guid ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Goal { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public Guid StatusId { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual SprintStatus Status { get; set; } = null!;

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
