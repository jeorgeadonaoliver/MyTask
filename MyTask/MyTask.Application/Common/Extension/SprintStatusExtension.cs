using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Features.SprintStatusManagement.Query.GetSprintStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Common.Extension
{
    public static class SprintStatusExtension
    {
        public static GetSprintStatusQueryDto MapTpGetSprintStatusQueryDto(this SprintStatus sprintStatus) 
        {
            return new GetSprintStatusQueryDto() 
            {
                Id = sprintStatus.StatusId,
                CreatedAt = sprintStatus.CreatedAt,
                Name = sprintStatus.Name,
            };
        } 
    }
}
