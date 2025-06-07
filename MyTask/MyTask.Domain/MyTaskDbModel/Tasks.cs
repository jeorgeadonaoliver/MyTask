namespace MyTask.Api.Client.MyTaskDbModel;

public partial class Tasks
{
    public Guid TaskId { get; set; }

    public Guid ListId { get; set; }

    public Guid? SprintId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public Guid StatusId { get; set; }

    public Guid PriorityId { get; set; }

    public decimal? EstimateHours { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? CompletedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    public virtual TaskList List { get; set; } = null!;

    public virtual TaskPriority Priority { get; set; } = null!;

    public virtual Sprint? Sprint { get; set; }

    public virtual TaskStatus Status { get; set; } = null!;

    public virtual ICollection<Subtask> Subtasks { get; set; } = new List<Subtask>();

    public virtual ICollection<TaskAssignment> TaskAssignments { get; set; } = new List<TaskAssignment>();

    public virtual ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
