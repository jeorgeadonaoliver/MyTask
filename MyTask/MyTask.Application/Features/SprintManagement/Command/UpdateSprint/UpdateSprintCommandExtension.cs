using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintManagement.Command.UpdateSprint
{
    public static class UpdateSprintCommandExtension
    {
        public static Sprint MapToSprint(this UpdateSprintCommand command) 
        {
            return new Sprint
            {
                SprintId = command.Id,
                EndDate = command.EndDate,
                Name = command.Name,
                ProjectId = command.ProjectId,
                StartDate = command.StartDate,
                StatusId = command.StatusId,
                Goal = command.Goal,
            };
        }
    }
}
