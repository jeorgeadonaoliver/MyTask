using MyTask.Application.Common;
using System.Linq.Expressions;

namespace MyTask.Application.Contracts;

public interface IGenericRepository<T> where T : class
{
    public Task<Result<bool>> CreateAsync(T entity);

    public Task<Result<IEnumerable<T>>> ReadAsync();

    public Task<Result<bool>> DeleteAsync(T entity);

    public Task<Result<bool>> UpdateAsync(Expression<Func<T, bool>> predicate, LambdaExpression updateExpression);
}
