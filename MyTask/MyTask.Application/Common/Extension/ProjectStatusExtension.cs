using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Features.ProjectStatusManagement.Query.GetAllProjectStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Common.Extension
{
    public static class ProjectStatusExtension
    {
        public static GetAllProjectStatusQueryDto MapToGetAllProjectStatusQueryDto(this ProjectStatus projectStatus) {

            return new GetAllProjectStatusQueryDto()
            {
                Id = projectStatus.StatusId,
                CreatedAt = projectStatus.CreatedAt,
                Name = projectStatus.Name,
            };
        }
    }
}
