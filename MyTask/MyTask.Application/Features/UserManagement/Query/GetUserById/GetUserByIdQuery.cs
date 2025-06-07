using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.UserManagement.Query.GetUserById
{
    public record GetUserByIdQuery(Guid id) : IRequest<GetUserByIdDto>;

}
