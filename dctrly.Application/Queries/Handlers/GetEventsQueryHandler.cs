using dctrly.Domain.Entities;
using dctrly.Infrastructure.Data.Interfaces;
using MediatR;

namespace dctrly.Application.Queries.Handlers;

public class GetEventsQueryHandler(IEventRepository eventRepository) : IRequestHandler<GetEventsQuery, IEnumerable<Event>>
{
    public async Task<IEnumerable<Event>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        var result = await eventRepository.GetEventsAsync(request.TitleFilter, request.DescriptionFilter,
            request.DateFromFilter, request.DateToFilter, cancellationToken);

        return result;
    }
}