using dctrly.Domain.Entities;
using dctrly.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dctrly.Infrastructure.Data.Repositories;

/// <inheritdoc cref="IEventRepository"/>
internal class EventRepository(DoctorlyDataContext context) : IEventRepository
{
    public async Task<Event?> GetEventAsync(int eventId, CancellationToken cancellationToken)
    {
        return await context.Events.FindAsync([eventId], cancellationToken: cancellationToken);
    }
    
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
        var @event = await context.Events.FindAsync([eventId], cancellationToken: cancellationToken);
        if (@event is null)
        {
            return;
        }
    
        context.Events.Remove(@event);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<Event?> UpdateAsync(Event updatedEvent, CancellationToken cancellationToken)
    {
        var existingEvent = await context.Events.FindAsync([updatedEvent.Id], cancellationToken);
        if (existingEvent is null)
        {
            return null;
        }
    
        existingEvent.Title = updatedEvent.Title;
        existingEvent.Description = updatedEvent.Description;
        existingEvent.StartDate = updatedEvent.StartDate;
        existingEvent.EndDate = updatedEvent.EndDate;
        
        await context.SaveChangesAsync(cancellationToken);
        return existingEvent;
    }
}