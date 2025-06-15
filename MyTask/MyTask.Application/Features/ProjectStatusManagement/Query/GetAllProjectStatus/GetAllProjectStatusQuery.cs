using MediatR;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectStatusManagement.Query.GetAllProjectStatus
{
    public record GetAllProjectStatusQuery : IRequest<IEnumerable<GetAllProjectStatusQueryDto>>, ICachableQuery
    {
        public string CacheKey => "GetAllProjectStatus";

        public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(5);
    }
}
