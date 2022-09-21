using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoProject.Application.Features.Commands.TagCommands.CreateTagCommands;

namespace PhotoProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommandRequest request)
        {
            CreateTagCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
