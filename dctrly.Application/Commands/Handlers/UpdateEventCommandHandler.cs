using dctrly.Domain.Entities;
using dctrly.Infrastructure.Data.Interfaces;
using MediatR;

namespace dctrly.Application.Commands.Handlers;

public class UpdateEventCommandHandler(IEventRepository eventRepository) : IRequestHandler<UpdateEventCommand>
{
    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var updatedEvent = new Event(request.Id, request.Name, request.Description, request.StartDate, request.EndDate);

        await eventRepository.UpdateAsync(updatedEvent, cancellationToken); 
    }
}