using Microsoft.EntityFrameworkCore;
using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;

namespace MyTask.Persistence.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyTaskDbContext context) : base(context) { }


        public async Task<User> GetUserByIdAsync(Guid guid) 
        {
            return await _context.Set<User>().AsNoTracking().SingleOrDefaultAsync(x => x.UserId == guid) 
                ?? throw new Exception("User Id not Found!");
        }

        public async Task<User> GetUserByEmailAsync(string email) 
        {
            return await _context.Set<User>().AsNoTracking().SingleOrDefaultAsync(x => x.Email == email)
                ?? throw new Exception("Email not Found!");
        }

        public async Task<bool> GetUsetByIdAndPasswordAsync(Guid guid, string password)
        {
            return await _context.Set<User>().AsNoTracking().AnyAsync(x => x.UserId == guid && x.PasswordHash == password);
        }

        public async Task<bool> AnyUserByIdAsync(Guid guid)
        {
            return await _context.Set<User>().AnyAsync(x => x.UserId == guid);
        }

        public async Task<bool> AnyUserByEmailAsync(string email)
        {
            return await _context.Set<User>().AsNoTracking().AnyAsync(x => x.Email == email);
        }

        public async Task ChangeUserPasswordAsync(User user)
        {
            await _context.Users.Where(x => x.UserId == user.UserId)
                .ExecuteUpdateAsync(y => y.SetProperty(z => z.PasswordHash, user.PasswordHash));
        }

        public async Task<Guid> CreateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return user.UserId;
        }
    }
}
