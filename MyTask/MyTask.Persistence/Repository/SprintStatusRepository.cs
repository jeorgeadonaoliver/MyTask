using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Persistence.Repository
{
    public class SprintStatusRepository : GenericRepository<SprintStatus>, ISprintStatusRepository
    {
        public SprintStatusRepository(MyTaskDbContext context) : base(context)
        {
            
        }

        public async Task<Result<bool>> IsSprintStatusExist(string name) 
        {
            var data = await _context.Set<SprintStatus>().AsNoTracking().AnyAsync(c => c.Name == name);
            return Result<bool>.Success(data);
        }

        public async Task<Result<bool>> IsSprintStatusExist(Guid guid)
        {
            var data = await _context.Set<SprintStatus>().AsNoTracking().AnyAsync(c => c.StatusId == guid);
            return Result<bool>.Success(data);
        }

        public async Task<Result<bool>> UpdateSprintStatusAsync(SprintStatus sprintStatus) 
        {
            Expression<Func<SetPropertyCalls<SprintStatus>, SetPropertyCalls<SprintStatus>>> expression =
                setter => setter
                .SetProperty(sp => sp.Name, sprintStatus.Name);

            var data = await UpdateAsync(x => x.StatusId == sprintStatus.StatusId, expression);
            return data;
                
        }
    }
}
