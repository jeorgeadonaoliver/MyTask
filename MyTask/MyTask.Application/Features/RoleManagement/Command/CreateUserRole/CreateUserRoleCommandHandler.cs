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

            try
            {
                request.Id = Guid.NewGuid();
                request.CreatedAt = DateTime.Now;
                var data = await _repository.CreateAsync(request.MapToUserRole());

                return data.Value;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error on CreateUserRoleCommandHandler: {ex}");
                return false;
            }
            
        }
    }
}
