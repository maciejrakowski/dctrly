using MediatR;

namespace dctrly.Application.Commands;

public class AcceptAppointmentCommand : IRequest
{
    public int AttendeeId { get; set; }
}