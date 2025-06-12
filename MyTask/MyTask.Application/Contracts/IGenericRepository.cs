namespace MyTask.Application.Contracts;

public interface IGenericRepository<T>
{
    public Task CreateAsync(T entity);

    public Task<IEnumerable<T>> ReadAsync();

    public Task UpdateAsync(T entity);

    public Task DeleteAsync(T entity);

}
