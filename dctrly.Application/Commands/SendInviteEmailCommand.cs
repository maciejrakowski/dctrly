using MediatR;

namespace dctrly.Application.Commands;

public class SendInviteEmailCommand : IRequest
{
    public int AttendeeId { get; set; }
}