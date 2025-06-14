using MediatR;
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
        public CreateUserRoleCommandHandler(IUserRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserRoleCommandValidation(_repository);
            var result = await validator.ValidateAsync(request, cancellationToken);
            result.CheckValidationResult();

            request.Id = Guid.NewGuid();
            request.CreatedAt = DateTime.Now;
            var data = await _repository.CreateAsync(request.MapToUserRole());

            return data.Value;
        }
    }
}
