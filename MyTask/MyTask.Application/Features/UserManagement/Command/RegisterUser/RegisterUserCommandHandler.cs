using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.UserManagement.Command.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    IUserRepository _repository;
    public RegisterUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new RegisterUserCommandValidator(_repository);
        var result = await validator.ValidateAsync(request, cancellationToken);
        result.CheckValidationResult();

        request.Id = Guid.NewGuid();
        var data = await _repository.CreateAsync(request.MapToEntity());
        
        return data.Value;
    }
}
