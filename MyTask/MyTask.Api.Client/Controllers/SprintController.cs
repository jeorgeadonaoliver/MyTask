using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllSprint() 
        {
            var data = await _mediator.Send(new GetSprintQuery());
            return Ok(data);
        }
    }
}
