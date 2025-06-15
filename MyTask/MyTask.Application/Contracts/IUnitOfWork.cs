using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Contracts
{
    public interface IUnitOfWork
    {
        public Task BeginTransactionAsync();

        public Task CommitTransactionAsync();

        public Task RollbackTransactionAsync();
    }
}
