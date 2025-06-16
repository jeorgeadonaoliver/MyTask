using MediatR;
using MyTask.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintManagement.Command.CreateSprint
{
    public class CreateSprintCommand : BaseDto, IRequest<bool>
    {
        public Guid ProjectId { get; set; }

        public string Name { get; set; } = null!;

        public string? Goal { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public Guid StatusId { get; set; }
    }
}
