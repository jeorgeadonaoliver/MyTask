using MediatR;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintManagement.Query.GetSprint
{
    public class GetSprintQuery : IRequest<IEnumerable<GetSprintQueryDto>>, ICachableQuery
    {
        public string CacheKey => "GetSprintQuery";

        public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(10);
    }
}
