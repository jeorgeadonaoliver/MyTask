using MyTask.Api.Client.MyTaskDbModel;

namespace MyTask.Application.Contracts;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User> GetUserByEmailAsync(string email);

    public Task<User> GetUserByIdAsync(Guid guid);

    public Task<bool> AnyUserByIdAsync(Guid guid);

    public Task<bool> AnyUserByEmailAsync(string email);

    public Task<bool> GetUsetByIdAndPasswordAsync(Guid guid, string email);

    public Task ChangeUserPasswordAsync(User user);

    public Task<Guid> CreateUserAsync(User user);
}
