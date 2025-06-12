using MyTask.Application.Common.Dto;

namespace MyTask.Application.Features.UserManagement.Query.GetUser;

public class GetUserQueryDto : BaseDto
{
    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public Guid RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
