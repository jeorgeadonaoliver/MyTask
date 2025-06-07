using FluentValidation;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.UserManagement.Command.ChangeUserPassword
{
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

        private async Task<bool> IsUserExisting(ChangeUserPasswordCommand cmd, CancellationToken cancellationToken) {

            return await _repository.AnyUserByIdAsync(cmd.Id);
        }
    }
}
