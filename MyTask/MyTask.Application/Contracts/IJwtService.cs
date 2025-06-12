using MyTask.Api.Client.MyTaskDbModel;

namespace MyTask.Application.Contracts;

public interface IJwtService
{
    public  Task<string> GenerateToken(User user, string role);
}
