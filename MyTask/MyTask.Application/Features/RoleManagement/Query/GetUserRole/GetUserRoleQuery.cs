using MediatR;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.RoleManagement.Query.GetUserRole
{
    public class GetUserRoleQuery : IRequest<IEnumerable<GetUserRoleQueryDto>>, ICachableQuery
    {
        public string CacheKey => "GetUserRoleQuery";

        public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(5);
    }
}
