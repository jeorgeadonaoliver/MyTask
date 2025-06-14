using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectManagement.Query.GetAllProjects
{
    public class GetAllProjectQueryDto :BaseDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public Guid OwnerId { get; set; }

        public Guid StatusId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual User Owner { get; set; } = null!;
    }
}
