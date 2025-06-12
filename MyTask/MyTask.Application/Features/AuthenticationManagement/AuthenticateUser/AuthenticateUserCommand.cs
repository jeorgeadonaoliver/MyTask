using MediatR;
using MyTask.Application.Common.Dto;

namespace MyTask.Application.Features.AuthenticationManagement.AuthenticateUser;

public class AuthenticateUserCommand : IRequest<AuthResponseDto>
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}
