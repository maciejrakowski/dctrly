using dctrly.Infrastructure.Data.Interfaces;
using MediatR;

namespace dctrly.Application.Commands.Handlers;

public class AcceptAppointmentCommandHandler(IAttendeeRepository attendeeRepository)
    : IRequestHandler<AcceptAppointmentCommand>
{
    public async Task Handle(AcceptAppointmentCommand request, CancellationToken cancellationToken)
    {
        var attendee = await attendeeRepository.GetAttendeeAsync(request.AttendeeId, cancellationToken);
        if (attendee is null)
        {
            throw new Exception("Attendee not found");
        }

        attendee.AcceptAppointment();
        await attendeeRepository.SaveChangesAsync(cancellationToken);
    }
}