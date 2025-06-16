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
            try 
            {
                var response = await _repository.CreateAsync(request.MapToProjectstatus());
                return response.Value;
            } 
            catch (Exception ex) 
            {
                Console.WriteLine($"Error on CreateProjectStatusCommand: {ex}");
                return false;
            }

            
        }
    }
}
