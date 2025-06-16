using FluentValidation;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectStatusManagement.Command.UpdateProjectStatus
{
    public class UpdateProjectStatusCommandValidation : AbstractValidator<UpdateProjectStatusCommand>
    {
        private readonly IProjectStatusRepository _repository;
        public UpdateProjectStatusCommandValidation(IProjectStatusRepository repository)
        {
            _repository = repository;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("UpdateProjectStatusCommand must not be null!");

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Project Id must not be null!")
                .MustAsync(IsProjectStatusIdExist)
                .WithMessage("Project Status does not exist!");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Status name must not be null!");
        }

        private async Task<bool> IsProjectStatusIdExist(Guid guid, CancellationToken cancellationToken) 
        {
            try
            {
                return await _repository.IsProjectStatusExist(guid);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error on IsProjectStatusIdExist: {ex}");
                return false;
            }

        }
    }
}
