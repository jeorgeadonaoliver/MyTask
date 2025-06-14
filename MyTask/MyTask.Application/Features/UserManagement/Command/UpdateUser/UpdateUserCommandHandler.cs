using MediatR;
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
        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserCommandValidation(_repository);
            var result = await validator.ValidateAsync(request, cancellationToken);
            result.CheckValidationResult();

            request.UpdatedAt = DateTime.Now;
            var data = await _repository.UpdateUserAsync(request.MapToUser());
            return data;
        }
    }
}
