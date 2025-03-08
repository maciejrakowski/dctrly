using dctrly.Infrastructure.Data.Interfaces;
using MediatR;

namespace dctrly.Application.Commands.Handlers;

public class DeleteEventCommandHandler(IEventRepository eventRepository, IAttendeeRepository attendeeRepository) : IRequestHandler<DeleteEventCommand>
{
    public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var attendees = await attendeeRepository.GetAttendeesByEventIdAsync(request.Id, cancellationToken);
        foreach (var attendee in attendees)
        {
            // send some kind of communication that appointment has been deleted
            attendee.RejectAppointment();
            // or delete the entries (depending on app concept)
        }
        
        await attendeeRepository.SaveChangesAsync(cancellationToken);
        
        await eventRepository.DeleteAsync(request.Id, cancellationToken);
    }
}