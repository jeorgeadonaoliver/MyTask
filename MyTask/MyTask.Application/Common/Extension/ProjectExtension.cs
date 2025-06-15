using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Features.ProjectManagement.Query.GetAllProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Common.Extension
{
    public static class ProjectExtension
    {
        public static GetAllProjectQueryDto MapToGetAllProjectQueryDto(this Project project) {

            return new GetAllProjectQueryDto() { 
            
                Id = project.ProjectId,
                CreatedAt = project.CreatedAt,
                Description = project.Description,
                Name = project.Name,
                OwnerId = project.OwnerId,  
                StatusId = project.StatusId
            };
        }
    }
}
