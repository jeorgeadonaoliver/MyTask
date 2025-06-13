using MyTask.Application.Common;

namespace MyTask.Application.Contracts;

public interface IGenericRepository<T>
{
    public Task<Result<bool>> CreateAsync(T entity);

    public Task<Result<IEnumerable<T>>> ReadAsync();

    public Task<Result<bool>> UpdateAsync(T entity);

    public Task<Result<bool>> DeleteAsync(T entity);

}
