using FluentValidation;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintManagement.Command.UpdateSprint
{
    public class UpdateSprintCommandValidation : AbstractValidator<UpdateSprintCommand>
    {
        private readonly ISprintRepository _repository;
        public UpdateSprintCommandValidation(ISprintRepository repository)
        {
            _repository = repository;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("UpdateSprintCommand must not be null");

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Sprint ID mut not be null!")
                .MustAsync(IsSprintExist)
                .WithMessage("Sprint does not Exist!");
        }

        private async Task<bool> IsSprintExist(Guid guid, CancellationToken cancellationToken) 
        {
            var data = await _repository.IsSprintExist(guid);
            return data.Value;
                
        }
    }
}
