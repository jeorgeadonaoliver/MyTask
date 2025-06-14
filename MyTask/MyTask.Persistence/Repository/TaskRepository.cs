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
    public class TaskRepository : GenericRepository<Tasks>, ITaskRepository
    {
        public TaskRepository(MyTaskDbContext myTaskDb) : base(myTaskDb) { }
        
    }
}
