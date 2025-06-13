using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.UserManagement.Command.ChangeUserPassword;

public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, string>
{
    private readonly IUserRepository _repository;

    public ChangeUserPasswordCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var validator = new ChangeUserPasswordCommandValidator(_repository);
        var result = await validator.ValidateAsync(request, cancellationToken);
        result.CheckValidationResult();

        var data = await _repository.ChangeUserPasswordAsync(request.MapToEntity());
        return data.Value 
            ? "Change Password Successful!"
            : "Change Password Failed!";
    }
}
