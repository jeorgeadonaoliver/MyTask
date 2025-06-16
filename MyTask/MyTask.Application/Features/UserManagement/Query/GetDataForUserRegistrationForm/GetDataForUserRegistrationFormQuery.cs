using MediatR;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.UserManagement.Query.GetDataForUserRegistrationForm;

public record GetDataForUserRegistrationFormQuery : IRequest<IEnumerable<GetDataForUserRegistrationFormQueryDto>>, ICachableQuery
{
    public string CacheKey => "GetDataForUserRegistrationFormQuery";

    public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(10);
}

