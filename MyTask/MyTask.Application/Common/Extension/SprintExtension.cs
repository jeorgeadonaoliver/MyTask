using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Features.SprintManagement.Query.GetSprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Common.Extension
{
    public static class SprintExtension
    {
        public static GetSprintQueryDto MapToGetSprintQueryDto(this Sprint sprint) 
        {
            return new GetSprintQueryDto()
            {
                Id = sprint.SprintId,
                EndDate = sprint.EndDate,
                Name = sprint.Name,
                Goal = sprint.Goal,
                ProjectId = sprint.ProjectId,
                StartDate = sprint.StartDate,
                StatusId = sprint.StatusId,
            };
        }
    }
}
