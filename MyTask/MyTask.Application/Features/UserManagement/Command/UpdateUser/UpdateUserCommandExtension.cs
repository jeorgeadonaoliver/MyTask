using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.UserManagement.Command.UpdateUser
{
    public static class UpdateUserCommandExtension
    {
        public static User MapToUser(this UpdateUserCommand command)
        {
            return new User() { 
            
                UserId = command.Id,
                FullName = command.FullName,
                IsActive = command.IsActive,
                UpdatedAt = command.UpdatedAt,
                RoleId = command.RoleId,
                AvatarUrl = command.AvatarUrl,
            };
        }
    }
}
