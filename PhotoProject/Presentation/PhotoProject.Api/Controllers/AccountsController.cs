using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhotoProject.Application.Features.Commands.AccountCommands.UserLoginCommands;
using PhotoProject.Application.Features.Commands.AccountCommands.UserRegisterCommands;

namespace PhotoProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("UserRegister")]
        public async Task<IActionResult> UserRegister(UserRegisterCommandRequest request)
        {
            UserRegisterCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin(UserLoginCommandRequest request)
        {
            UserLoginCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        //todo add GoogleLogin
        
    }
}
