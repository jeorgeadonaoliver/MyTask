using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.RoleManagement.Command.UpdateUserRole
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, bool>
    {
        private readonly IUserRoleRepository _repository;
        public UpdateUserRoleCommandHandler(IUserRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repository.UpdateRoleAsync(request.MapToUserRole());
                return data;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error on UpdateRoleAsync method: {ex}");
                return false;
            }
        }
    }
}
