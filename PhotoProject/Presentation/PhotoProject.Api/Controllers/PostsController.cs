using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoProject.Application.Features.Commands.PostCommands;

namespace PhotoProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Member")]
        [HttpPost("PostShare")]
        public async Task<IActionResult> PostShare([FromForm]PostShareCommandRequest request)
        {
            request.IdentityName = HttpContext.User.Identity.Name;
            //todo write error
            PostShareCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
