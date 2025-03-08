using dctrly.Infrastructure.Data.Interfaces;
using MediatR;

namespace dctrly.Application.Commands.Handlers;

public class DeleteEventCommandHandler(IEventRepository eventRepository) : IRequestHandler<DeleteEventCommand>
{
    public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        await eventRepository.DeleteAsync(request.Id, cancellationToken);
    }
}