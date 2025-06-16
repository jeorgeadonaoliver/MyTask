using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Contracts
{
    public interface ISprintRepository : IGenericRepository<Sprint>
    {
        public Task<Result<bool>> IsSprintExist(Guid guid);

        public Task<Result<bool>> IsSprintExist(string name);

        public Task<Result<bool>> UpdateSprintExist(Sprint sprint);
    }
}
