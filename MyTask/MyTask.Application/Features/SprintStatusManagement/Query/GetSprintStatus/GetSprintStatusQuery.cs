using MediatR;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintStatusManagement.Query.GetSprintStatus
{
    public record GetSprintStatusQuery : IRequest<IEnumerable<GetSprintStatusQueryDto>>, ICachableQuery
    {
        public string CacheKey => "GetSprintStatusQueryDto";

        public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(5);
    }
}
