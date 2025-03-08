using dctrly.Domain.Entities;
using dctrly.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dctrly.Infrastructure.Data.Repositories;

/// <inheritdoc cref="IEventRepository"/>
internal class EventRepository(DoctorlyDataContext context) : IEventRepository
{
    public async Task<IEnumerable<Event>> GetEventsAsync(string? titleFilter, string? descriptionFilter,
        DateTime? dateFromFilter, DateTime? dateToFilter, CancellationToken cancellationToken)
    {
        var result = await context.Events
            .Where(x => titleFilter == null || x.Title.Contains(titleFilter))
            .Where(x => descriptionFilter == null ||
                        (x.Description != null && x.Description.Contains(descriptionFilter)))
            // I assume that any event that is even partially within dateFrom - dateTo filter will be included
            .Where(x => dateFromFilter == null || x.EndDate >= dateFromFilter)
            .Where(x => dateToFilter == null || x.StartDate <= dateToFilter)
            .ToListAsync(cancellationToken);

        return result;
    }

    public async Task<Event> CreateAsync(Event @event, CancellationToken cancellationToken)
    {
        await context.Events.AddAsync(@event, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return @event;
    }

    public async Task DeleteAsync(int eventId, CancellationToken cancellationToken)
    {
        var entity = await context.Events.FindAsync([eventId], cancellationToken: cancellationToken);
        if (entity is null)
        {
            return;
        }

        context.Events.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}