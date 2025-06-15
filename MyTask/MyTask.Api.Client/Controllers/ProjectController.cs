using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTask.Application.Features.ProjectManagement.Command;
using MyTask.Application.Features.ProjectManagement.Query.GetAllProjects;

namespace MyTask.Api.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects() 
        {
            var data = await _mediator.Send(new GetAllProjectsQuery());
            return Ok(data);
        }

        [HttpPost("CreateProject")]
        public async Task<IActionResult> CreateProject(CreateProjectCommand command) 
        {
            var result = await _mediator.Send(command);
            return Ok(result ? "Create Project Successfule!" : "Create Project Failed!");
        }
    }
}
