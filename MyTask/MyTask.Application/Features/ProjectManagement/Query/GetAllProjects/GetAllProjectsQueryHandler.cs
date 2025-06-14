using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectManagement.Query.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<GetAllProjectQueryDto>>
    {
        private readonly IProjectRepository _repository;
        public GetAllProjectsQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetAllProjectQueryDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.ReadAsync();
            return data.Value.Select(x => x.MapToGetAllProjectQueryDto()).ToList();

        }
    }
}
