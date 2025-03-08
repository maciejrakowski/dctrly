using MediatR;

namespace dctrly.Application.Commands;

public class RejectAppointmentCommand : IRequest
{
    public int AttendeeId { get; set; }
}