using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Contracts
{
    public interface IJwtService
    {
        public  Task<string> GenerateToken(User user, string role);
    }
}
