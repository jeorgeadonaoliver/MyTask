using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common;

namespace MyTask.Application.Contracts;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<Result<User>> GetUserByEmailAsync(string email);

    public Task<Result<User>> GetUserByIdAsync(Guid guid);

    public Task<Result<bool>> AnyUserByIdAsync(Guid guid);

    public Task<Result<bool>> AnyUserByEmailAsync(string email);

    public Task<Result<bool>> GetUsetByIdAndPasswordAsync(Guid guid, string email);

    public Task<bool> ChangeUserPasswordAsync(User user);

    public Task<bool> UpdateUserAsync(User user);

}
