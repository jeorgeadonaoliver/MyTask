using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintStatusManagement.Command.CreateSprintStatus
{
    public class CreateSprintStatusCommandHandler: IRequestHandler<CreateSprintStatusCommand, bool>
    {
        private readonly ISprintStatusRepository _repository;
        private readonly IMemoryCache _memoryCache;
        public CreateSprintStatusCommandHandler(ISprintStatusRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        public async Task<bool> Handle(CreateSprintStatusCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.CreateAsync(request.MapToSprintStatus());
            _memoryCache.Remove("GetSprintStatusQueryDto");
            return data.Value;
        }
    }
}
