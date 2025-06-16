using FluentValidation;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintManagement.Command.CreateSprint
{
    public class CreateSprintCommandValidation : AbstractValidator<CreateSprintCommand>
    {
        private readonly ISprintRepository _repository;
        public CreateSprintCommandValidation(ISprintRepository repository )
        {
            _repository = repository;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("CreateSprintCommand must not be null!");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Sprint name must not be null!")
                .MustAsync(IsSprintExist)
                .WithMessage("Sprint name already Exist!");

            RuleFor(x => x.StartDate)
                .NotNull()
                .WithMessage("Start date is required!")
                .LessThan(x => x.EndDate)
                .WithMessage("Start date must be less than end date!");

            RuleFor(x => x.EndDate)
                .NotNull()
                .WithMessage("End date must not be null!");
        }

        private async Task<bool> IsSprintExist(string name, CancellationToken cancellationToken) 
        {
            var data = await _repository.IsSprintExist(name);
            return !data.Value;
        }
    }
}
