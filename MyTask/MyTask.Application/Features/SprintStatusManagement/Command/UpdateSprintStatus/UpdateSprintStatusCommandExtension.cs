using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintStatusManagement.Command.UpdateSprintStatus
{
    public static class UpdateSprintStatusCommandExtension 
    {
        public static SprintStatus MapToSprintStatus(this UpdateSprintStatusCommand command) 
        {
            return new SprintStatus()
            {
                StatusId = command.Id,
                Name = command.Name,
            };
        }
    }
}
