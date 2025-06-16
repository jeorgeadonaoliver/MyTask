using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.RoleManagement.Query.GetUserRole
{
    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQuery, IEnumerable<GetUserRoleQueryDto>>
    {
        private readonly IUserRoleRepository _repository;
        public GetUserRoleQueryHandler(IUserRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetUserRoleQueryDto>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.ReadAsync();
            var result = data.Value.Select(x => x.MapToGetUserRoleQueryDto()).ToList();
            return result;
        }
    }
}
