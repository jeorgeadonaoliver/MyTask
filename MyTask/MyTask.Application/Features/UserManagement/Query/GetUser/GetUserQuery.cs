using MediatR;

namespace MyTask.Application.Features.UserManagement.Query.GetUser;

public record GetUserQuery : IRequest<IEnumerable<GetUserQueryDto>>; 
