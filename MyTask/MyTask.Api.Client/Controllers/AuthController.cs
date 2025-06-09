using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyTask.Application.Features.AuthenticationManagement.AuthenticateUser;
using MyTask.Application.Features.UserManagement.Command.ChangeUserPassword;
using MyTask.Application.Features.UserManagement.Command.RegisterUser;
using MyTask.Application.Features.UserManagement.Query.GetUserById;

namespace MyTask.Api.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassordAsync(ChangeUserPasswordCommand cmd) 
        {
            var result = await _mediator.Send(cmd);
            return Ok("Change Password Successful!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthenticateUserCommand cmd)
        {
            var result = await _mediator.Send(cmd);

            if (result is null) {

                return Unauthorized("Invalid email or password.");
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // true in production
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddDays(1),
                Path = "/"
            };

            Response.Cookies.Append("authToken", result.token, cookieOptions);

            return Ok(new { 
                message = "Login successful!",
                role = result.role,
                fullName = result.fullName,
            });

            //return result != null ? Ok(result) : Unauthorized();
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand cmd) 
        {
            var newUserId = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetUserById), new { id = newUserId }, newUserId);    
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(Guid id) 
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(result);
        }
    }
}
