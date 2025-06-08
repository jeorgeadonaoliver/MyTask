using MediatR;
using MyTask.Application.Common.Dto;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.AuthenticationManagement.AuthenticateUser
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthResponseDto>
    {
        private readonly IAuthService _authservice;
        private readonly IJwtService _jwtservice;
        private readonly AuthResponseDto _responseDto;
        public AuthenticateUserCommandHandler(IAuthService authService, IJwtService jwtService)
        {
            _authservice = authService;
            _jwtservice = jwtService;
            _responseDto = new AuthResponseDto();
        }

        public async Task<AuthResponseDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new AuthenticateUserCommandValidator(_authservice);
            var result = await validator.ValidateAsync(request, cancellationToken);
            result.CheckValidationResult();

            var data = await _authservice.GetUserByEmailAsync(request.Email);
            var token = await _jwtservice.GenerateToken(request.MapToEntity(), data.UserRoles.Name);

            _responseDto.fullName = data.FullName;
            _responseDto.token = token;
            _responseDto.role = data.UserRoles.Name;

            return _responseDto;
        }
    }
}
