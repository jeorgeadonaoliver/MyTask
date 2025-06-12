using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTask.Application.Features.UserManagement.Query.GetDataForUserRegistrationForm;
using MyTask.Application.Features.UserManagement.Query.GetUser;

namespace MyTask.Api.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetRoleForUserRegistrationForm")]
        public async Task<IActionResult> GetRoleForUserRegistrationForm() 
        {
            var data = await _mediator.Send(new GetDataForUserRegistrationFormQuery());
            return Ok(data);
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers() {

            var data = await _mediator.Send(new GetUserQuery());
            return Ok(data);
        }
    }
}
