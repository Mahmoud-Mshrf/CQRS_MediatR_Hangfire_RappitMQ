using ApplicationLayer.Dtos;
using ApplicationLayer.Features.Users.GetUserProfile;
using ApplicationLayer.Features.Users.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CQRS_MediatR_Hangfire_RappitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register-new-user")]
        public async Task<IActionResult> RegisterAsync(RegisterUserCommand command)
        {
           var id = await _mediator.Send(command);
            return Ok(id);
        }
        [HttpGet("get-user-profile")]
        public async Task<ActionResult<UserProfileDto>> GetUserAsync([Required]int id)
        {
            var query = new GetUserQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
