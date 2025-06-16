using MyTask.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintManagement.Query.GetSprint
{
    public class GetSprintQueryDto : BaseDto
    {
        public Guid ProjectId { get; set; }

        public string Name { get; set; } = null!;

        public string? Goal { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public Guid StatusId { get; set; }
    }
}
