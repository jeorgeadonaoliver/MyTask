using MediatR;
using MyTask.Application.Common.Dto;

namespace MyTask.Application.Features.UserManagement.Command.ChangeUserPassword;

public class ChangeUserPasswordCommand : BaseDto, IRequest<Unit>
{
    public string Password { get; set; } = "";

}
