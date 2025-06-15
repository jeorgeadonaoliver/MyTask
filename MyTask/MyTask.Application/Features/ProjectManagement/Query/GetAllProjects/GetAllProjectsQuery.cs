using MediatR;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectManagement.Query.GetAllProjects
{
    public record GetAllProjectsQuery : IRequest<IEnumerable<GetAllProjectQueryDto>>, ICachableQuery
    {
        public string CacheKey => "GetAllProjectQuery";

        public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(10);
    }

}
