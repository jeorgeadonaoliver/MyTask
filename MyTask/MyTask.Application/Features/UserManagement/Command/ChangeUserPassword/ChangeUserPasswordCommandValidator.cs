using FluentValidation;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.UserManagement.Command.ChangeUserPassword;

public class ChangeUserPasswordCommandValidator : AbstractValidator<ChangeUserPasswordCommand>
{
    private readonly IUserRepository _repository;
    public ChangeUserPasswordCommandValidator(IUserRepository repository)
    {
        _repository = repository;

        RuleFor(x => x)
            .NotNull()
            .WithMessage("ChangeUserPasswordCommand must not be null!")
            .MustAsync(IsUserExisting)
            .WithMessage("User is not existing!");
    }

    private async Task<bool> IsUserExisting(ChangeUserPasswordCommand cmd, CancellationToken cancellationToken) 
    {
        try 
        {
            var data = await _repository.AnyUserByIdAsync(cmd.Id);
            return data.Value;
        } 
        catch (Exception ex) 
        {
            Console.WriteLine($"Error on IsUserExisting method: {ex}");
            return false;
        }

    }
}
