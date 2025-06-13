using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common;

namespace MyTask.Application.Contracts;

public interface IAuthService : IGenericRepository<User>
{
    public Task<Result<bool>> CheckUserEmailExistAsync(string email);

    public Task<Result<string>> GetUserPasswordlByEmailAsync(string email);

    public Task<Result<User>> GetUserByEmailAsync(string email);

}
