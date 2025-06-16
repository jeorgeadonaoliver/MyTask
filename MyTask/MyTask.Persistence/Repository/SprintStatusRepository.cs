using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Persistence.Repository
{
    public class SprintStatusRepository : GenericRepository<SprintStatus>, ISprintStatusRepository
    {
        public SprintStatusRepository(MyTaskDbContext context) : base(context)
        {
            
        }
    }
}
