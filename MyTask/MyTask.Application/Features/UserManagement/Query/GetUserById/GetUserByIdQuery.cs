using MediatR;

namespace MyTask.Application.Features.UserManagement.Query.GetUserById
{
    public record GetUserByIdQuery(Guid id) : IRequest<GetUserByIdDto>;

}
