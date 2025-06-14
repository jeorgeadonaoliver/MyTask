using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyTask.Api.Client.Interface;
using MyTask.Application.Features.AuthenticationManagement.AuthenticateUser;
using MyTask.Application.Features.UserManagement.Command.ChangeUserPassword;

namespace MyTask.Api.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IMediator _mediator;
        ICookieService _cookieService;
        public AuthController(IMediator mediator, ICookieService cookieService)
        {
            _mediator = mediator;
            _cookieService = cookieService;
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassordAsync(ChangeUserPasswordCommand cmd) 
        {
            var result = await _mediator.Send(cmd);
            return Ok(result ? "Change password successful!" : "Failed on changing password!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthenticateUserCommand cmd)
        {
            var result = await _mediator.Send(cmd);
            await _cookieService.SetToken( Response, result.token);
            return Ok(result);
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("authToken");
            return Ok("Logout successfull!");
        }
    }
}
