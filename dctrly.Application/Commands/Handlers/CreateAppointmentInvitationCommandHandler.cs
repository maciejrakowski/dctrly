using dctrly.Domain.Entities;
using dctrly.Infrastructure.Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace dctrly.Application.Commands.Handlers;

public class CreateAppointmentInvitationCommandHandler(
    IEventRepository eventRepository,
    IAttendeeRepository attendeeRepository,
    ILogger<CreateAppointmentInvitationCommandHandler> logger)
    : IRequestHandler<CreateAppointmentInvitationCommand, int?>
{
    public async Task<int?> Handle(CreateAppointmentInvitationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var @event = await eventRepository.GetEventAsync(request.EventId, cancellationToken);
            if (@event is null)
            {
                logger.LogWarning($"Event with id={@request.EventId} not found");
                return null;
            }

            var attendee = new Attendee(request.EventId, request.Name, request.Email);
            var id = await attendeeRepository.CreateAppointmentInvitationAsync(attendee);

            // send email maybe?
            
            return id;
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while booking appointment");
            
            // Depending on the project's concept, you could throw an exception here instead of returning false
            return null;
        }
    }
}