using MediatR;

namespace MyTask.Application.Features.UserManagement.Query.GetDataForUserRegistrationForm;

public record GetDataForUserRegistrationFormQuery : IRequest<IEnumerable<GetDataForUserRegistrationFormQueryDto>>;

