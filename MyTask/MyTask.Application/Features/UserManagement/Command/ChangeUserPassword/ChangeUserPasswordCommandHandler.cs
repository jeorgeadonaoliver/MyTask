using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.UserManagement.Command.ChangeUserPassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, Unit>
    {
        private readonly IUserRepository _repository;

        public ChangeUserPasswordCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var validator = new ChangeUserPasswordCommandValidator(_repository);
            var result = await validator.ValidateAsync(request, cancellationToken);
            result.CheckValidationResult();

            await _repository.ChangeUserPasswordAsync(request.MapToEntity());
            return Unit.Value;
        }
    }
}
