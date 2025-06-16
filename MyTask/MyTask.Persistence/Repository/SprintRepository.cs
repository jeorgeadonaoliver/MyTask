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
    public class SprintRepository : GenericRepository<Sprint>, ISprintRepository
    {
        public SprintRepository(MyTaskDbContext context) : base(context)
        {
            
        }

        public async Task<Result<bool>> IsSprintExist(string name) 
        {
            var data = await _context.Sprints.AsNoTracking().AnyAsync(x => x.Name == name);
            return Result<bool>.Success(data);
        }

        public async Task<Result<bool>> IsSprintExist(Guid guid)
        {
            var data = await _context.Sprints.AsNoTracking().AnyAsync(x => x.SprintId == guid);
            return Result<bool>.Success(data);
        }

        public async Task<Result<bool>> UpdateSprintExist(Sprint sprint)
        {
            Expression<Func<SetPropertyCalls<Sprint>, SetPropertyCalls<Sprint>>> expression =
                setter => setter
                .SetProperty(sp => sp.StartDate, sprint.StartDate)
                .SetProperty(sp => sp.EndDate, sprint.EndDate)
                .SetProperty(sp => sp.StatusId, sprint.StatusId)
                .SetProperty(sp => sp.ProjectId, sprint.ProjectId)
                .SetProperty(sp => sp.Name, sprint.Name);

            var data = await UpdateAsync(x => x.SprintId == sprint.SprintId, expression);
            return data;
        }
    }
}
