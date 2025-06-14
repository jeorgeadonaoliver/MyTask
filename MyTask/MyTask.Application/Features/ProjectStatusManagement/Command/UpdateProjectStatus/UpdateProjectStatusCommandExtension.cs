using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectStatusManagement.Command.UpdateProjectStatus
{
    public static class UpdateProjectStatusCommandExtension 
    {
        public static ProjectStatus MapToProjectStatus(this UpdateProjectStatusCommand command) 
        {
            return new ProjectStatus() 
            {
                StatusId = command.Id,
                Name = command.Name
            };
        }
    }
}
