using FluentValidation;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.UserManagement.Command.UpdateUser
{
    public class UpdateUserCommandValidation : AbstractValidator<UpdateUserCommand>
    {
        private readonly IUserRepository _repository;
        public UpdateUserCommandValidation(IUserRepository repository)
        {
            _repository = repository;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("UpdateUserCommand must not be null!");
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("User Id is required!")
                .MustAsync(IsUserExist)
                .WithMessage("User does not Exist!");
        }

        private async Task<bool> IsUserExist(Guid guid, CancellationToken cancellationToken) 
        {
            var data = await _repository.AnyUserByIdAsync(guid);
            return data.Value;
        }
    }
}
