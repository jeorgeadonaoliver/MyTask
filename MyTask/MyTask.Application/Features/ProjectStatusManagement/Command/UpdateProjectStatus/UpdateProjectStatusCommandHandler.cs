using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectStatusManagement.Command.UpdateProjectStatus
{
    public class UpdateProjectStatusCommandHandler : IRequestHandler<UpdateProjectStatusCommand, bool>
    {
        private readonly IProjectStatusRepository _repository;
        private readonly IMemoryCache _memoryCache;
        public UpdateProjectStatusCommandHandler(IProjectStatusRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        public async Task<bool> Handle(UpdateProjectStatusCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.UpdateProjectStatus(request.MapToProjectStatus());
            _memoryCache.Remove("GetAllProjectStatus");
            return response;
        }
    }
}
