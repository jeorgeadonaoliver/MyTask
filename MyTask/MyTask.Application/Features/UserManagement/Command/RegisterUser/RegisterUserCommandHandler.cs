using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.UserManagement.Command.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    IUserRepository _repository;
    IUnitOfWork _unitOfWork;
    public RegisterUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new RegisterUserCommandValidator(_repository);
        var result = await validator.ValidateAsync(request, cancellationToken);
        result.CheckValidationResult();

        await _unitOfWork.BeginTransactionAsync();
        try 
        {
            request.Id = Guid.NewGuid();
            var data = await _repository.CreateAsync(request.MapToEntity());
            await _unitOfWork.CommitTransactionAsync();

            return data.Value;
        }
        catch (Exception ex) 
        {
            await _unitOfWork.RollbackTransactionAsync();
            return false;
        }
    }
}
