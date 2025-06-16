using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintStatusManagement.Command.UpdateSprintStatus
{
    public class UpdateSprintStatusCommandValidation : AbstractValidator<UpdateSprintStatusCommand>
    {
        private readonly ISprintStatusRepository _repository;
        private readonly IMemoryCache _memoryCache;
        public UpdateSprintStatusCommandValidation(ISprintStatusRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("UpdateSprintStatusCommand must not be null!");

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("UpdateSprintStatusCommand ID must not be null!")
                .MustAsync(IsSprintStatusCommandExist)
                .WithMessage("Sprint Status already Exist!");
        }

        private async Task<bool> IsSprintStatusCommandExist(Guid guid, CancellationToken cancellationToken) 
        {
            var data = await _repository.IsSprintStatusExist(guid);
            return data.Value;
        }
    }
}
