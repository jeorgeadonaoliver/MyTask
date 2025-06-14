using FluentValidation;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.RoleManagement.Command.UpdateUserRole
{
    public class UpdateUserRoleCommandValidation : AbstractValidator<UpdateUserRoleCommand>
    {
        private readonly IUserRoleRepository _repository;
        public UpdateUserRoleCommandValidation(IUserRoleRepository repository)
        {
            _repository = repository;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("UpdateUserRoleCommand must not be null!");

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("User Role Id must not be null!")
                .MustAsync(IsUserRoleExist)
                .WithMessage("User Role does not exist!");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("User Role name must not be null!");
        }

        private async Task<bool> IsUserRoleExist(Guid guid, CancellationToken cancellationToken) 
        {
            return await _repository.IsUserRoleExistById(guid);
        }
    }
}
