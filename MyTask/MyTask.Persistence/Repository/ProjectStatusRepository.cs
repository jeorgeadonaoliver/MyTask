using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;
using System.Linq.Expressions;

namespace MyTask.Persistence.Repository
{
    public class ProjectStatusRepository : GenericRepository<ProjectStatus>, IProjectStatusRepository
    {
        public ProjectStatusRepository(MyTaskDbContext myTaskDbContext) : base(myTaskDbContext) { }

        public async Task<bool> IsProjectStatusExist(string statusName)
        {
            var result = await _context.Set<ProjectStatus>().AsNoTracking().AnyAsync(x => x.Name == statusName);
            return result;
        }

        public async Task<bool> IsProjectStatusExist(Guid guid)
        {
            var result = await _context.Set<ProjectStatus>().AsNoTracking().AnyAsync(x => x.StatusId == guid);
            return result;
        }

        public async Task<bool> UpdateProjectStatus(ProjectStatus projectStatus) 
        {
            Expression<Func<SetPropertyCalls<ProjectStatus>, SetPropertyCalls<ProjectStatus>>> updateExpression =
                setter => setter
            .SetProperty(sp => sp.StatusId, projectStatus.StatusId)
            .SetProperty(sp => sp.Name, projectStatus.Name);

            var result = await UpdateAsync(x => x.StatusId == projectStatus.StatusId,updateExpression);

            return result.Value;
        }
    }
}
