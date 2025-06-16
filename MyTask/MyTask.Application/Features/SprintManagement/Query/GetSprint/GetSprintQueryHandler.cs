using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintManagement.Query.GetSprint
{
    public class GetSprintQueryHandler : IRequestHandler<GetSprintQuery, IEnumerable<GetSprintQueryDto>>
    {
        private readonly ISprintRepository _repository;

        public GetSprintQueryHandler(ISprintRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<GetSprintQueryDto>> Handle(GetSprintQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.ReadAsync();
            var result = data.Value.Select(x => x.MapToGetSprintQueryDto()).ToList();

            return result;
        }
    }
}
