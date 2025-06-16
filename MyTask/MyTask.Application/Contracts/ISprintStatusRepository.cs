using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Contracts
{
    public interface ISprintStatusRepository : IGenericRepository<SprintStatus>
    {
        public Task<Result<bool>> IsSprintStatusExist(string name);

        public Task<Result<bool>> IsSprintStatusExist(Guid guid);

        public Task<Result<bool>> UpdateSprintStatusAsync(SprintStatus sprintStatus);
    }
}
