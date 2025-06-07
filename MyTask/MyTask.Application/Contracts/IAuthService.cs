using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Contracts
{
    public interface IAuthService : IGenericRepository<User>
    {
        public Task<bool> CheckUserEmailExistAsync(string email);

        public Task<string> GetUserPasswordlByEmailAsync(string email);

        public Task<string> GetUserRoleByEmailAsync(string email);

    }
}
