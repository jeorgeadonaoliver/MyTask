using Microsoft.EntityFrameworkCore;
using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;

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

        public async Task<Result<bool>> ChangeUserPasswordAsync(User user)
        {
            var rowAffected = await _context.Users.Where(x => x.UserId == user.UserId)
                .ExecuteUpdateAsync(y => y.SetProperty(z => z.PasswordHash, user.PasswordHash));

            return rowAffected > 0 
                ? Result<bool>.Success(true) 
                : Result<bool>.Failed("Error on ChangeUserPasswordAsync");
        }
    }
}
