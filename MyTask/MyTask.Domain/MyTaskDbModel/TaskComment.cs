namespace MyTask.Api.Client.MyTaskDbModel;

public partial class TaskComment
{
    public Guid CommentId { get; set; }

    public Guid TaskId { get; set; }

    public Guid AuthorId { get; set; }

    public string Content { get; set; } = null!;

    public Guid? ParentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<TaskComment> InverseParent { get; set; } = new List<TaskComment>();

    public virtual TaskComment? Parent { get; set; }

    public virtual Tasks Task { get; set; } = null!;
}
