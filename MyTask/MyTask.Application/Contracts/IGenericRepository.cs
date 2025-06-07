using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Contracts
{
    public interface IGenericRepository<T>
    {
        public Task CreateAsync(T entity);

        public Task<IEnumerable<T>> ReadAsync();

        public Task UpdateAsync(T entity);

        public Task DeleteAsync(T entity);

    }
}
