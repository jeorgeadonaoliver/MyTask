using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.RoleManagement.Command.CreateUserRole
{
    public static class CreateUserRoleCommandExtension
    {
        public static UserRole MapToUserRole(this CreateUserRoleCommand command) 
        {
            return new UserRole() 
            {
                RoleId = command.Id,
                Name = command.Name,
                CreatedAt = command.CreatedAt
            };
        }
    }
}
