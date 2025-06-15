using MediatR;
using MyTask.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectManagement.Command
{
    public class CreateProjectCommand : BaseDto, IRequest<bool>
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public Guid OwnerId { get; set; }

        public Guid StatusId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
