using MediatR;
using MyTask.Api.Client.MyTaskDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.AuthenticationManagement.AuthenticateUser
{
    public class AuthenticateUserCommand : IRequest<string>
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
