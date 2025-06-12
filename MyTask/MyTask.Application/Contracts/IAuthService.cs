using MyTask.Api.Client.MyTaskDbModel;

namespace MyTask.Application.Contracts;

public interface IAuthService : IGenericRepository<User>
{
    public Task<bool> CheckUserEmailExistAsync(string email);

    public Task<string> GetUserPasswordlByEmailAsync(string email);

    public Task<User> GetUserByEmailAsync(string email);

}
