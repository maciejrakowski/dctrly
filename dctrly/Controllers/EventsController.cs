using dctrly.Application.Commands;
using dctrly.Contracts.Events;
using dctrly.Contracts.Extensions.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dctrly.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController(ILogger<EventsController> logger, IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetEventsAsync([FromBody] GetEventsRequest request)
    {
        try
        {
            var query = request.ToGetEventsQuery();
            var events = await mediator.Send(query);

            return Ok(events);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error getting events");
            return Problem(statusCode: 400, title: "BadRequest", detail: "Error getting events");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateEventAsync([FromBody] CreateEventCommand command)
    {
        try
        {
            var id = await mediator.Send(command);
            return Ok(id);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error creating event");
            return Problem(statusCode: 400, title: "BadRequest", detail: "Error creating event");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateEventCommand command)
    {
        try
        {
            await mediator.Send(command);
            return Ok();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error updating event");
            return Problem(statusCode: 400, title: "BadRequest", detail: "Error updating event");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEventAsync([FromRoute] int id)
    {
        try
        {
            await mediator.Send(new DeleteEventCommand { Id = id });
            return Ok();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error deleting event");
            return Problem(statusCode: 400, title: "BadRequest", detail: "Error deleting event");
        }
    }
}