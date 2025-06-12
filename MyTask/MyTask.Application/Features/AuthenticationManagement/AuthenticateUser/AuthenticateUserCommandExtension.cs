using MyTask.Api.Client.MyTaskDbModel;

namespace MyTask.Application.Features.AuthenticationManagement.AuthenticateUser;

public static class AuthenticateUserCommandExtension
{
    public static User MapToEntity(this AuthenticateUserCommand command) 
    {
        return new User
        {
            Email = command.Email,
            PasswordHash = command.Password
        };
    }
}
