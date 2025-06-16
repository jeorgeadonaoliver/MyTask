using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.UserManagement.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _repository;
        private readonly IMemoryCache _memoryCache;
        public UpdateUserCommandHandler(IUserRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            request.UpdatedAt = DateTime.Now;
            var data = await _repository.UpdateUserAsync(request.MapToUser());
            _memoryCache.Remove($"GetUserByIdQuery:{request.Id}");
            _memoryCache.Remove("GetUserQuery");
            return data;
        }
    }
}
