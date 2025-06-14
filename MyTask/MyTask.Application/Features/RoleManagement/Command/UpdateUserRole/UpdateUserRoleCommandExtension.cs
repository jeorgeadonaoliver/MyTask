using MediatR;
using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.RoleManagement.Command.UpdateUserRole
{
    public static class UpdateUserRoleCommandExtension
    {
        public static UserRole MapToUserRole(this UpdateUserRoleCommand command)
        {
            return new UserRole() { 
            
                RoleId = command.Id,
                Name = command.Name,
            };
        }
    }
}
