using Microsoft.EntityFrameworkCore.Storage;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Persistence.Repository
{
    public class MyTaskDbUnitOfWork : IUnitOfWork
    {
        private readonly MyTaskDbContext _dbContext;
        private IDbContextTransaction? _transaction; 

        public MyTaskDbUnitOfWork(MyTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _dbContext.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }
    }
}
