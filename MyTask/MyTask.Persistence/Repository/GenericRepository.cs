using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyTask.Application.Common;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;
using System.Linq;
using System.Linq.Expressions;

namespace MyTask.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MyTaskDbContext _context;
        public GenericRepository(MyTaskDbContext context)
        {
            _context = context;
        }

        public async Task<Result<bool>> CreateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            var rowAffected = await _context.SaveChangesAsync();

            return rowAffected > 0
                ? Result<bool>.Success(true)
                : Result<bool>.Failed("Creating Record error!");
        }

        public async Task<Result<IEnumerable<T>>> ReadAsync()
        {
            var data = await _context.Set<T>().ToListAsync();
            return data is not null
                ? Result<IEnumerable<T>>.Success(data)
                : Result<IEnumerable<T>>.Failed("Error on Reading Data");           
        }

        public async Task<Result<bool>> DeleteAsync(T entity)
        {
            _context.Remove(entity).State = EntityState.Deleted;
            var rowAffected = await _context.SaveChangesAsync();

            return rowAffected > 0
                ? Result<bool>.Success(true)
                : Result<bool>.Failed("Error on deleting Record!");
        }

        public async Task<Result<bool>> UpdateAsync(Expression<Func<T, bool>> predicate, LambdaExpression updateExpression)
        {
            var typedUpdateExpression = (Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>>)updateExpression;
            var result = await _context.Set<T>()
                 .Where(predicate)
                 .ExecuteUpdateAsync(typedUpdateExpression);

            return result > 0
                ? Result<bool>.Success(true)
                : Result<bool>.Failed($"Updating {typeof(T).Name} Failed!");
        }
    }
}
