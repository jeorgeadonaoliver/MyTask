using Microsoft.EntityFrameworkCore;
using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;
using MyTask.Persistence.Repository;

namespace MyTask.Security
{
    public class AuthService : GenericRepository<User>, IAuthService
    {
        public AuthService(MyTaskDbContext context) : base(context) { }

        public async Task<string> GetUserPasswordlByEmailAsync(string email) 
        {
            var user = await _context.Set<User>().AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
            return user.PasswordHash;   
        }

        public async Task<bool> CheckUserEmailExistAsync(string email)
        {
            return await _context.Set<User>().AsNoTracking().AnyAsync(x => x.Email == email);
        }

        public async Task<string> GetUserRoleByEmailAsync(string email)
        {
            var user = await _context.Set<User>().Include(u => u.UserRoles).AsNoTracking().FirstOrDefaultAsync(x => x.Email == email) ??
               throw new Exception("User email does not exist");

            return user.UserRoles.Name;
        }
    }
}
