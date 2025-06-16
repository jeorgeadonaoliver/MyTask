using FluentValidation;
using Isopoh.Cryptography.Argon2;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.AuthenticationManagement.AuthenticateUser;

public class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
{
    IAuthService _authService;
    public AuthenticateUserCommandValidator(IAuthService authService)
    {
        _authService = authService;

        RuleFor(x => x.Email)
            .NotNull()
            .WithMessage("Email must not be null!")
            .EmailAddress()
            .WithMessage("Please enter proper email format!")
            .MustAsync(IsEmailExist)
            .WithMessage("Email Does not Exist!");

        RuleFor(x => x)
            .NotNull()
            .WithMessage("AuthenticateUserCommand must not be null!")
            .MustAsync(IsValidPassword)
            .WithMessage("User Password is invalid");

        RuleFor(x => x.Password)
            .NotNull()
            .WithMessage("Password must not be null!");
    }

    private async Task<bool> IsEmailExist(string email, CancellationToken cancellationToken) 
    {
        try 
        {
            var result = await _authService.CheckUserEmailExistAsync(email);
            return result.Value;

        } 
        catch (Exception ex) 
        {
            Console.WriteLine($"Error on CheckUserEmailExistAsync method: {ex}");
            return false;
        }

    }

    private async Task<bool> IsValidPassword(AuthenticateUserCommand cmd, CancellationToken cancellationToken) 
    {
        try
        {
            var passwordHash = await _authService.GetUserPasswordlByEmailAsync(cmd.Email);
            var isValidPassword = Argon2.Verify(passwordHash.Value, cmd.Password);

            return isValidPassword;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error on IsValidPassword method: {ex}");
            return false;
        }

    }
}
