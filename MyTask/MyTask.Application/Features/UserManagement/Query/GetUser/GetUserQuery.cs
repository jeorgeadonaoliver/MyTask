using MediatR;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.UserManagement.Query.GetUser;

public class GetUserQuery : IRequest<IEnumerable<GetUserQueryDto>>, ICachableQuery
{
    public string CacheKey => "GetUserQuery";

    public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(5);
} 
