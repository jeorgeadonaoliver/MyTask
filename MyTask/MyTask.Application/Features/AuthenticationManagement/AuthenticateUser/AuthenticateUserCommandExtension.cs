using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.AuthenticationManagement.AuthenticateUser
{
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
}
