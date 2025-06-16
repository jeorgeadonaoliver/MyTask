using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTask.Application.Features.SprintManagement.Command.CreateSprint;
using MyTask.Application.Features.SprintManagement.Command.UpdateSprint;
using MyTask.Application.Features.SprintManagement.Query.GetSprint;

namespace MyTask.Api.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SprintController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SprintController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllSprint")]
        public async Task<IActionResult> GetAllSprintAsync() 
        {
            var data = await _mediator.Send(new GetSprintQuery());
            return Ok(data);
        }

        [HttpPost("CreateSprint")]
        public async Task<IActionResult> CreateSprintAsync(CreateSprintCommand command) 
        {
            var data = await _mediator.Send(command);
            return Ok(data ? "Create Sprint Successfull!" : "Failed on creating sprint!" );
        }

        [HttpPut("UpdateSprint")]
        public async Task<IActionResult> UpdateSprintAsync(UpdateSprintCommand command) 
        {
            var data = await _mediator.Send(command);
            return Ok(data ? "Updating Sprint Successful!" : "Failed on updating Sprint!");
        }
    }
}
