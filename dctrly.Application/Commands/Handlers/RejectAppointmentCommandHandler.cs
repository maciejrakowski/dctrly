using dctrly.Infrastructure.Data.Interfaces;
using MediatR;

namespace dctrly.Application.Commands.Handlers;

public class RejectAppointmentCommandHandler(IAttendeeRepository attendeeRepository)
    : IRequestHandler<RejectAppointmentCommand>
{
    public async Task Handle(RejectAppointmentCommand request, CancellationToken cancellationToken)
    {
        var attendee = await attendeeRepository.GetAttendeeAsync(request.AttendeeId, cancellationToken);
        if (attendee is null)
        {
            throw new Exception("Attendee not found");
        }

        attendee.RejectAppointment();
        await attendeeRepository.SaveChangesAsync(cancellationToken);
    }
}