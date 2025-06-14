using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;
using System.Linq.Expressions;

namespace MyTask.Persistence.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyTaskDbContext context) : base(context) { }

        public async Task<Result<User>> GetUserByIdAsync(Guid guid) 
        {
            var data = await _context.Set<User>().AsNoTracking().SingleOrDefaultAsync(x => x.UserId == guid);
            return data == null
            ? Result<User>.Failed("Error on GetUserByIdAsync!")
            : Result<User>.Success(data);
        }

        public async Task<Result<User>> GetUserByEmailAsync(string email) 
        {
            var data = await _context.Set<User>().AsNoTracking().SingleOrDefaultAsync(x => x.Email == email);
            return data == null
                ? Result<User>.Failed("Error on GetUserByEmailAsync!")
                : Result<User>.Success(data);
        }

        public async Task<Result<bool>> GetUsetByIdAndPasswordAsync(Guid guid, string password)
        {
            var data = await _context.Set<User>().AsNoTracking().AnyAsync(x => x.UserId == guid && x.PasswordHash == password);
            return Result<bool>.Success(data);
        }

        public async Task<Result<bool>> AnyUserByIdAsync(Guid guid)
        {
            var data = await _context.Set<User>().AnyAsync(x => x.UserId == guid);
            return Result<bool>.Success(data);
        }

        public async Task<Result<bool>> AnyUserByEmailAsync(string email)
        {
            var data = await _context.Set<User>().AsNoTracking().AnyAsync(x => x.Email == email);
            return Result<bool>.Success(data);
        }

        public async Task<bool> ChangeUserPasswordAsync(User user)
        {
            Expression<Func<SetPropertyCalls<User>, SetPropertyCalls<User>>> expression =
                setter => setter
                .SetProperty(sp => sp.PasswordHash, user.PasswordHash);

            var rowAffected = await UpdateAsync(x => x.UserId == user.UserId, expression);

            return rowAffected.Value;
        }

        public async Task<bool> UpdateUserAsync(User user) 
        {
            Expression<Func<SetPropertyCalls<User>, SetPropertyCalls<User>>> expression =
                setter => setter
                .SetProperty(sp => sp.UserId, user.UserId)
                .SetProperty(sp => sp.RoleId, user.RoleId)
                .SetProperty(sp => sp.AvatarUrl, user.AvatarUrl)
                .SetProperty(sp => sp.FullName, user.FullName)
                .SetProperty(sp => sp.IsActive, user.IsActive)
                .SetProperty(sp => sp.UpdatedAt, user.UpdatedAt);

            var rowAffected = await UpdateAsync(x => x.UserId == user.UserId, expression);
            return rowAffected.Value;
        }
    }
}
