using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTask.Application.Features.SprintStatusManagement.Query.GetSprintStatus;
using System.Runtime.InteropServices;

namespace MyTask.Api.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SprintStatusController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SprintStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetSprintStatus")]
        public async Task<IActionResult> GetSprintStatus() 
        {
            var data = await _mediator.Send(new GetSprintStatusQuery());
            return Ok(data);
        }
    }
}
