using Isopoh.Cryptography.Argon2;
using MyTask.Api.Client.MyTaskDbModel;

namespace MyTask.Application.Features.UserManagement.Command.RegisterUser;

public static class RegisterUserCommandExtension
{
    public static User MapToEntity(this RegisterUserCommand cmd) {

        return new User()
        {
            UserId = Guid.NewGuid(),
            FullName = cmd.FullName,
            Email = cmd.Email,
            PasswordHash = Argon2.Hash(cmd.PasswordHash),
            AvatarUrl = cmd.AvatarUrl,
            RoleId = cmd.RoleId,
            CreatedAt = DateTime.Now,
            IsActive = true,
        };
    }
}
