using MediatR;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.UserManagement.Query.GetUserById
{
    public record GetUserByIdQuery(Guid id) : IRequest<GetUserByIdDto>, ICachableQuery
    {
        public string CacheKey => $"GetUserByIdQuery:{id}";

        public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(5);
    }

}
