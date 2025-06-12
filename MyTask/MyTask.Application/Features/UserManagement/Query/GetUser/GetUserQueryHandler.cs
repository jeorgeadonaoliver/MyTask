using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.UserManagement.Query.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<GetUserQueryDto>>
{
    private readonly IUserRepository _repository;
    public GetUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetUserQueryDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.ReadAsync();
        return data.Select(x => x.MapToGetUserQueryDto()).ToList();
            
    }
}
