using dctrly.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dctrly.Controllers;

[ApiController]
[Route("[controller]")]
public class AttendeesController(ILogger<EventsController> logger, IMediator mediator) : ControllerBase
{
    [HttpPost("create-appointment-invitation")]
    public async Task<IActionResult> CreateAppointmentInvitationAsync([FromBody] CreateAppointmentInvitationCommand command)
    {
        var id = await mediator.Send(command);
        return Ok(id);
    }

    [HttpPost("accept-appointment-invitation")]
    public async Task<IActionResult> AcceptAppointmentInvitationAsync([FromBody] AcceptAppointmentCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpPost("reject-appointment-invitation")]
    public async Task<IActionResult> RejectAppointmentInvitationAsync([FromBody] RejectAppointmentCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
}