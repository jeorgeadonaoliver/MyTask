using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintStatusManagement.Query.GetSprintStatus
{
    public class GetSprintStatusQueryHandler : IRequestHandler<GetSprintStatusQuery, IEnumerable<GetSprintStatusQueryDto>>
    {
        private readonly ISprintStatusRepository _repository;
        public GetSprintStatusQueryHandler(ISprintStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetSprintStatusQueryDto>> Handle(GetSprintStatusQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.ReadAsync();
            var result = data.Value.Select(x => x.MapTpGetSprintStatusQueryDto()).ToList();

            return result;
        }
    }
}
