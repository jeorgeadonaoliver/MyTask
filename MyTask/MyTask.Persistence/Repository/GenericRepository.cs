using Microsoft.EntityFrameworkCore;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;

namespace MyTask.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MyTaskDbContext _context;
        public GenericRepository(MyTaskDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
