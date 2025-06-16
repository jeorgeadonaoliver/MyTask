using MediatR;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;
        public CreateProjectStatusCommandHandler(IProjectStatusRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        public async Task<bool> Handle(CreateProjectStatusCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.CreateAsync(request.MapToProjectstatus());
            _memoryCache.Remove("GetAllProjectStatus");
            return response.Value;         
        }
    }
}
