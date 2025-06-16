using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintManagement.Command.UpdateSprint
{
    public class UpdateSprintCommandHandler : IRequestHandler<UpdateSprintCommand, bool>
    {
        private readonly ISprintRepository _repository;
        private readonly IMemoryCache _memoryCache;
        public UpdateSprintCommandHandler(ISprintRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        public async Task<bool> Handle(UpdateSprintCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.UpdateSprintExist(request.MapToSprint());
            _memoryCache.Remove("GetSprintQuery");

            return data.Value;
        }
    }
}
