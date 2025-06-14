using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectStatusManagement.Command.CreateProjectStatus
{
    public class CreateProjectStatusCommandHandler : IRequestHandler<CreateProjectStatusCommand, bool>
    {
        private readonly IProjectStatusRepository _repository;
        public CreateProjectStatusCommandHandler(IProjectStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateProjectStatusCommand request, CancellationToken cancellationToken)
        {
            request.Id = Guid.NewGuid();
            request.CreatedAt = DateTime.Now;

            var validator = new CreateProjectStatusCommandValidation(_repository);
            var result = await validator.ValidateAsync(request, cancellationToken);
            result.CheckValidationResult();

            var response = await _repository.CreateAsync(request.MapToProjectstatus());
            
            return response.Value;
        }
    }
}
