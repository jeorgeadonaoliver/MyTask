using MediatR;

namespace MyTask.Application.Features.UserManagement.Command.RegisterUser;

public class RegisterUserCommand : IRequest<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public Guid RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
