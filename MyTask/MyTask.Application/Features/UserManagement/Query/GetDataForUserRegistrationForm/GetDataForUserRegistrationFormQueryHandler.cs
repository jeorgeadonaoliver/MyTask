using MediatR;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.UserManagement.Query.GetDataForUserRegistrationForm;

public class GetDataForUserRegistrationFormQueryHandler : IRequestHandler<GetDataForUserRegistrationFormQuery, IEnumerable<GetDataForUserRegistrationFormQueryDto>>
{
    private readonly IUserRoleRepository _repository;
    public GetDataForUserRegistrationFormQueryHandler(IUserRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetDataForUserRegistrationFormQueryDto>> Handle(GetDataForUserRegistrationFormQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.ReadAsync();
        return data.Value.Select(u => u.MapToGetDataForUserRegistrationForm()).ToList();
    }
}
