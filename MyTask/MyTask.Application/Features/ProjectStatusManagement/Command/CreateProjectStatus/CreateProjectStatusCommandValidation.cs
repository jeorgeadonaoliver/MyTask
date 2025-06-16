using FluentValidation;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectStatusManagement.Command.CreateProjectStatus
{
    public class CreateProjectStatusCommandValidation : AbstractValidator<CreateProjectStatusCommand>
    {
        private readonly IProjectStatusRepository _repository;

        public CreateProjectStatusCommandValidation(IProjectStatusRepository repository)
        {
            _repository = repository;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("CreateProjectStatusCommand must not be null!");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Project Status name must not be null!")
                .MustAsync(IsProjectStatusNameExist);
           
        }

        private async Task<bool> IsProjectStatusNameExist(string statusName, CancellationToken cancellationToken) 
        {
            try
            {
                return !await _repository.IsProjectStatusExist(statusName);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error on IsProjectStatusNameExist method: {ex}");
                return false;
            }

        }
    }
}
