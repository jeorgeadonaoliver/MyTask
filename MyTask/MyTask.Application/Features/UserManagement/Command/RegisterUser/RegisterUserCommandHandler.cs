using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.UserManagement.Command.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    IUserRepository _repository;
    public RegisterUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new RegisterUserCommandValidator(_repository);
        var result = await validator.ValidateAsync(request, cancellationToken);
        result.CheckValidationResult();

        var data = await _repository.CreateAsync(request.MapToEntity());
        
        return data.Value ? request.Id : Guid.NewGuid();
    }
}
