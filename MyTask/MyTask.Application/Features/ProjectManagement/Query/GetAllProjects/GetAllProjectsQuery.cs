using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectManagement.Query.GetAllProjects
{
    public record GetAllProjectsQuery : IRequest<IEnumerable<GetAllProjectQueryDto>>;
    
}
