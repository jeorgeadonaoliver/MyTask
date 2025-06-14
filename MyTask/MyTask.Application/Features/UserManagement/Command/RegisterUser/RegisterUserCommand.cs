using MediatR;
using MyTask.Application.Common.Dto;
using System.Numerics;

namespace MyTask.Application.Features.UserManagement.Command.RegisterUser;

public class RegisterUserCommand : BaseDto, IRequest<bool>
{
    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public Guid RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
