using FluentValidation;
using Isopoh.Cryptography.Argon2;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.AuthenticationManagement.AuthenticateUser
{
    public class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
    {
        IAuthService _authService;
        public AuthenticateUserCommandValidator(IAuthService authService)
        {
            _authService = authService;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("AuthenticateUserCommand must not be null!")
                .MustAsync(IsValidPassword)
                .WithMessage("User Password is invalid");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email must not be null!")
                .MustAsync(IsEmailExist)
                .WithMessage("Email Does not Exist!");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password must not be null!");
        }

        private async Task<bool> IsEmailExist(string email, CancellationToken cancellationToken) 
        {
            return await _authService.CheckUserEmailExistAsync(email);
        }

        private async Task<bool> IsValidPassword(AuthenticateUserCommand cmd, CancellationToken cancellationToken) 
        {
            var passwordHash = await _authService.GetUserPasswordlByEmailAsync(cmd.Email);
            var isValidPassword = Argon2.Verify(passwordHash, cmd.Password);

            return isValidPassword;
        }
    }
}
