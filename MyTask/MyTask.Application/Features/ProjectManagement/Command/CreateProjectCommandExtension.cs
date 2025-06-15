using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectManagement.Command
{
    public static class CreateProjectCommandExtension
    {
        public static Project MapToProject(this CreateProjectCommand command) 
        {
            return new Project { 
            
                Name = command.Name,
                CreatedAt = command.CreatedAt,
                Description = command.Description,
                OwnerId = command.OwnerId,
                StatusId = command.StatusId,
                ProjectId = command.Id, 
            };
        }
    }
}
