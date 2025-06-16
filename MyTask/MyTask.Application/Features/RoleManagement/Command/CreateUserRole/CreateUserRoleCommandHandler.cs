using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.RoleManagement.Command.CreateUserRole
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, bool>
    {
        private readonly IUserRoleRepository _repository;
        private readonly IMemoryCache _memoryCache;
        public CreateUserRoleCommandHandler(IUserRoleRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        public async Task<bool> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.CreateAsync(request.MapToUserRole());
            _memoryCache.Remove("GetUserRoleQuery");

            return data.Value;
        }
    }
}
