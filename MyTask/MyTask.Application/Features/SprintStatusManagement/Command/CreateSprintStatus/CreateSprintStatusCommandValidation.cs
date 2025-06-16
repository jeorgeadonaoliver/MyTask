using FluentValidation;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintStatusManagement.Command.CreateSprintStatus
{
    public class CreateSprintStatusCommandValidation : AbstractValidator<CreateSprintStatusCommand>
    {
        private readonly ISprintStatusRepository _repository;

        public CreateSprintStatusCommandValidation(ISprintStatusRepository repository)
        {
            _repository = repository;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("CreateSprintCommnad must not be null!");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Sprint status name must not be null!")
                .MustAsync(IsSprintStatusExist)
                .WithMessage("Sprint status name already exist!");
               
        }

        private async Task<bool> IsSprintStatusExist(string name, CancellationToken cancellationToken) 
        {
            var data = await _repository.IsSprintStatusExist(name);
            return !data.Value;
        }

    }
}
