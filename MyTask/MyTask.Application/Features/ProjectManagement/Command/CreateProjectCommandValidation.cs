using FluentValidation;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectManagement.Command
{
    public class CreateProjectCommandValidation : AbstractValidator<CreateProjectCommand>
    {
        private readonly IProjectRepository _repository;

        public CreateProjectCommandValidation(IProjectRepository repository)
        {
            _repository = repository;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("CreateProjectCommand must not be null!");

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Project Id must not be null!");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Project Name must not be null!")
                .MustAsync(IsProjectAlreadyExist)
                .WithMessage("Project already Exist!");
        }

        private async Task<bool> IsProjectAlreadyExist(string name, CancellationToken cancellationToken) 
        {
            return !await _repository.IsProjectExist(name);
        }
    }
}
