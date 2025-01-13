using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItemDto>> Create([FromBody] CreateToDoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult<bool>> UpdateStatus(Guid id, [FromBody] UpdateToDoStatusCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
