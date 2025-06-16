using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintStatusManagement.Command.CreateSprintStatus
{
    public static class CreateSprintStatusCommandExtension
    {
        public static SprintStatus MapToSprintStatus(this CreateSprintStatusCommand command) 
        {
            return new SprintStatus() 
            {
                StatusId = command.Id,
                CreatedAt = command.CreatedAt,
                Name = command.Name,
            };
        }
    }
}
