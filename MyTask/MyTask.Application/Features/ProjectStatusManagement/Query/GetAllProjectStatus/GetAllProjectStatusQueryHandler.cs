using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectStatusManagement.Query.GetAllProjectStatus
{
    public class GetAllProjectStatusQueryHandler : IRequestHandler<GetAllProjectStatusQuery, IEnumerable<GetAllProjectStatusQueryDto>>
    {
        private readonly IProjectStatusRepository _repository;
        public GetAllProjectStatusQueryHandler(IProjectStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetAllProjectStatusQueryDto>> Handle(GetAllProjectStatusQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.ReadAsync();
            return data.Value.Select(p => p.MapToGetAllProjectStatusQueryDto()).ToList();
        }
    }
}
