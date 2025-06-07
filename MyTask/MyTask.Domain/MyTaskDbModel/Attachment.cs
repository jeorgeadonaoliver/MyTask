namespace MyTask.Api.Client.MyTaskDbModel;

public partial class Attachment
{
    public Guid AttachmentId { get; set; }

    public Guid TaskId { get; set; }

    public string FileName { get; set; } = null!;

    public string FileUrl { get; set; } = null!;

    public Guid UploadedBy { get; set; }

    public DateTime UploadedAt { get; set; }

    public virtual Tasks Task { get; set; } = null!;

    public virtual User UploadedByNavigation { get; set; } = null!;
}
