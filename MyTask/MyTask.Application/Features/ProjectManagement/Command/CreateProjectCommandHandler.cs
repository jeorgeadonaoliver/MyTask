using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectManagement.Command
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, bool>
    {
        private readonly IProjectRepository _repository;
        private readonly IMemoryCache _memoryCache;

        public CreateProjectCommandHandler(IProjectRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        public async Task<bool> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.CreateAsync(request.MapToProject());
            _memoryCache.Remove("GetAllProjectQuery");
            return response.Value;
        }
    }
}
