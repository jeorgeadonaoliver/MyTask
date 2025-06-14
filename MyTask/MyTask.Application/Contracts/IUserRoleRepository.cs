using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common;

namespace MyTask.Application.Contracts
{
    public interface IUserRoleRepository : IGenericRepository<UserRole>
    {
        public Task<bool> IsUserRoleExistByName(string name);

        public Task<bool> IsUserRoleExistById(Guid guid);

        public Task<bool> UpdateRoleAsync(UserRole role);
    }
}
