using MediatR;
using MyTask.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.UserManagement.Command.UpdateUser
{
    public class UpdateUserCommand : BaseDto, IRequest<bool>
    {
        public string FullName { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? AvatarUrl { get; set; }

        public Guid RoleId { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
