using MediatR;
using MyTask.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.RoleManagement.Command.UpdateUserRole
{
    public class UpdateUserRoleCommand :BaseDto, IRequest<bool>
    {
        public string Name { get; set; } = null!;
    }
}
