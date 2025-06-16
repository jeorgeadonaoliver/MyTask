using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTask.Application.Features.ProjectStatusManagement.Command.CreateProjectStatus;
using MyTask.Application.Features.ProjectStatusManagement.Command.UpdateProjectStatus;
using MyTask.Application.Features.ProjectStatusManagement.Query.GetAllProjectStatus;

namespace MyTask.Api.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectStatusController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAllProjectStatus")]
        public async Task<IActionResult> GetAllProjectStatus() 
        {
            var data = await _mediator.Send(new GetAllProjectStatusQuery());
            return Ok(data);
        }

        [HttpPost("CreateProjectStatus")]
        public async Task<IActionResult> CreateProjectStatus(CreateProjectStatusCommand command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            var result = await _mediator.Send(command);

            return Ok(result ? "Create new Project Status Successful!" : "Failed on creating Project Status!");
        }

        [HttpPut("UpdateProjectStatus")]
        public async Task<IActionResult> UpdateProjectStatus(UpdateProjectStatusCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result ? "Updating Project Status Successful!" : "Failed on updating Project Status!");
        }
    }
}
