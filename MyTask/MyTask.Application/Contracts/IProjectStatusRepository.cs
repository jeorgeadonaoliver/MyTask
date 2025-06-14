using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Contracts
{
    public interface IProjectStatusRepository : IGenericRepository<ProjectStatus>
    {
        public Task<bool> IsProjectStatusExist(string statusName);

        public Task<bool> IsProjectStatusExist(Guid guid);

        public Task<bool> UpdateProjectStatus(ProjectStatus projectStatus);
    }
}
