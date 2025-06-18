using Microsoft.EntityFrameworkCore;
using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Persistence.Repository
{
    public class AuthService : GenericRepository<User>, IAuthService
    {
        public AuthService(MyTaskDbContext context) : base(context) { }

        public async Task<Result<string>> GetUserPasswordlByEmailAsync(string email)
        {
            var user = await _context.Set<User>().AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

            return user == null
                ? Result<string>.Failed("Error on GetUserPasswordlByEmailAsync!")
                : Result<string>.Success(user.PasswordHash);
        }

        public async Task<Result<bool>> CheckUserEmailExistAsync(string email)
        {
            var user = await _context.Set<User>().AsNoTracking().AnyAsync(x => x.Email == email);
            return Result<bool>.Success(user);
        }

        public async Task<Result<User>> GetUserByEmailAsync(string email)
        {
            var user = await _context.Set<User>().Include(u => u.UserRoles).AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

            return user == null
                ? Result<User>.Failed("Error on GetUserByEmailAsync!")
                : Result<User>.Success(user);
        }
    }
}
