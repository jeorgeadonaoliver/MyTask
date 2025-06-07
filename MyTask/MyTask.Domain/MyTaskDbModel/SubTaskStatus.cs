namespace MyTask.Api.Client.MyTaskDbModel;

public partial class SubTaskStatus
{
    public Guid StatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Name { get; set; } = null!;
}
