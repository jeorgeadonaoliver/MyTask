using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintStatusManagement.Command.UpdateSprintStatus
{
    public class UpdateSprintStatusCommandHandler : IRequestHandler<UpdateSprintStatusCommand, bool>
    {
        private readonly ISprintStatusRepository _repository;
        private readonly IMemoryCache _memoryCache;
        public UpdateSprintStatusCommandHandler(ISprintStatusRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        public async Task<bool> Handle(UpdateSprintStatusCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.UpdateSprintStatusAsync(request.MapToSprintStatus());
            _memoryCache.Remove("GetSprintStatusQueryDto");
            return data.Value;
        }
    }
}
