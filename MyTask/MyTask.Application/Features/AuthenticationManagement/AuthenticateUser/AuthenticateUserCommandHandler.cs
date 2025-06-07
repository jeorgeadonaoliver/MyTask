using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.AuthenticationManagement.AuthenticateUser
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        private readonly IAuthService _authservice;
        private readonly IJwtService _jwtservice;
        public AuthenticateUserCommandHandler(IAuthService authService, IJwtService jwtService)
        {
            _authservice = authService;
            _jwtservice = jwtService;
        }

        public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new AuthenticateUserCommandValidator(_authservice);
            var result = await validator.ValidateAsync(request, cancellationToken);
            result.CheckValidationResult();

            string role = await _authservice.GetUserRoleByEmailAsync(request.Email);
            var token = await _jwtservice.GenerateToken(request.MapToEntity(), role);

            return token;
        }
    }
}
