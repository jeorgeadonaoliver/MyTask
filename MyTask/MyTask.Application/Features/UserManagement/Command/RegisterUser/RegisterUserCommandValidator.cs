using FluentValidation;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.UserManagement.Command.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    private readonly IUserRepository _repository;
    public RegisterUserCommandValidator(IUserRepository repository)
    {
        _repository = repository;

        RuleFor(x => x)
            .NotNull()
            .WithMessage("RegisterUSerCommand must not be null!");

        RuleFor(x => x.Email)
            .NotNull()
            .WithMessage("Email is Required!")
            .MustAsync(IsEmailExist)
            .WithMessage("Email already Exist. Please proceed to login!");
    }

    private async Task<bool> IsEmailExist(string email, CancellationToken cancellationToken) 
    {
        try 
        {
            var data = await _repository.AnyUserByEmailAsync(email);
            return !data.Value;
        } 
        catch (Exception ex) 
        {
            Console.WriteLine($"Error on IsEmailExist method: {ex}");
            return false;
        }

    }

}
