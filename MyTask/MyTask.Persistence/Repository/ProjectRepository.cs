using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Persistence.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(MyTaskDbContext myTaskDbContext): base(myTaskDbContext) 
        {
            
        }

        public async Task<bool> IsProjectExist(string name) 
        {
            return await _context.Set<Project>().AsNoTracking().AnyAsync(x => x.Name == name);
        }
    }
}
