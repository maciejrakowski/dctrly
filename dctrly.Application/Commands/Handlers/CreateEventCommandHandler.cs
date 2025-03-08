using dctrly.Domain.Entities;
using dctrly.Infrastructure.Data.Interfaces;
using MediatR;

namespace dctrly.Application.Commands.Handlers;

public class CreateEventCommandHandler(IEventRepository eventRepository) : IRequestHandler<CreateEventCommand, int>
{
    public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var newEvent = new Event(request.Name, request.Description, request.StartDate, request.EndDate);
        newEvent = await eventRepository.CreateAsync(newEvent, cancellationToken);

        return newEvent.Id;
    }
}