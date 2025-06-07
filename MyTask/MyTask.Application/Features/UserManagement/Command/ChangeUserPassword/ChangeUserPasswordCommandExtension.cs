using Isopoh.Cryptography.Argon2;
using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.UserManagement.Command.ChangeUserPassword
{
    public static class ChangeUserPasswordCommandExtension
    {
        public static User MapToEntity(this ChangeUserPasswordCommand cmd) {

            return new User()
            {
                UserId = cmd.Id,
                PasswordHash = Argon2.Hash(cmd.Password),
            };
        }
    }
}
