using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTask.Application.Features.RoleManagement.Command.CreateUserRole;
using MyTask.Application.Features.RoleManagement.Command.UpdateUserRole;
using MyTask.Application.Features.RoleManagement.Query.GetUserRole;

namespace MyTask.Api.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserRoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllUserRole")]
        public async Task<IActionResult> GetAllUserRole() 
        {
            var data = await _mediator.Send(new GetUserRoleQuery());
            return Ok(data);
        }

        [HttpPost("CreateUserRole")]
        public async Task<IActionResult> CreateUserRole(CreateUserRoleCommand command) 
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            var response = await _mediator.Send(command);

            return Ok(response ? "Creating User Role Successful!" : "Failed on Creating User Role!");
        }

        [HttpPut("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleCommand command) 
        {
            var response = await _mediator.Send(command);
            return Ok(response ? "Updating User Role Successful!" : "Failed on Updating User Role!");
        }

    }
}
