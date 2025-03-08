using MediatR;

namespace dctrly.Application.Commands.Handlers;

public class SendInviteEmailCommandRequest:IRequestHandler<SendInviteEmailCommand>
{
    public Task Handle(SendInviteEmailCommand request, CancellationToken cancellationToken)
    {
        // handle communication here
        return Task.CompletedTask;
    }
}