using FluentValidation;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.RoleManagement.Command.CreateUserRole
{
    public class CreateUserRoleCommandValidation : AbstractValidator<CreateUserRoleCommand>
    {
        private readonly IUserRoleRepository _repository;
        public CreateUserRoleCommandValidation(IUserRoleRepository repository)
        {
            _repository = repository;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("CreateUserRoleCommand must not be null!");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("User Role name must not be null!")
                .MustAsync(IsUserRoleExist)
                .WithMessage("User Role already Exist!");

        }

        private async Task<bool> IsUserRoleExist(string name, CancellationToken cancellationToken)
        {
            try
            {
                return !await _repository.IsUserRoleExistByName(name);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error on IsUserRoleExist method: {ex}");
                return false;
            }

        }
    }
}
