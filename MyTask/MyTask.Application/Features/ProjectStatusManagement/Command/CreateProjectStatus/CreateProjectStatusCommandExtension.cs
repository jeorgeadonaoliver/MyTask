using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectStatusManagement.Command.CreateProjectStatus
{
    public static class CreateProjectStatusCommandExtension
    {
        public static ProjectStatus MapToProjectstatus(this CreateProjectStatusCommand command) 
        {
            return new ProjectStatus() 
            {
                CreatedAt = command.CreatedAt,
                Name = command.Name,
                StatusId = command.Id,
            };
        }
    }
}
