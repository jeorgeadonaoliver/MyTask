using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintManagement.Command.CreateSprint
{
    public static class CreateSprintCommandExtension
    {
        public static Sprint MapToSprint(this CreateSprintCommand command) 
        {
            return new Sprint()
            {
                Name = command.Name,
                EndDate = command.EndDate,
                Goal = command.Goal,
                ProjectId = command.ProjectId,
                SprintId = command.Id,
                StartDate = command.StartDate,
                StatusId = command.StatusId,
            };
        }
    }
}
