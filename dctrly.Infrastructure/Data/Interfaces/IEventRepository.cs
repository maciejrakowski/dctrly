using dctrly.Domain.Entities;

namespace dctrly.Infrastructure.Data.Interfaces;

/// <summary>
/// Defines a repository for managing and retrieving event data in the application.
/// </summary>
public interface IEventRepository
{
    /// <summary>
    /// Fetches a list of events based on the specified filters.
    /// </summary>
    /// <param name="titleFilter">An optional filter to search for events by their title. Only events containing this string in their title will be included.</param>
    /// <param name="descriptionFilter">An optional filter to search for events by their description. Only events containing this string in their description will be included.</param>
    /// <param name="dateFromFilter">An optional filter specifying the earliest end date of the events to include.</param>
    /// <param name="dateToFilter">An optional filter specifying the latest start date of the events to include.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of events that match the specified filters.
    /// </returns>
    Task<IEnumerable<Event>> GetEventsAsync(string? titleFilter, string? descriptionFilter,
        DateTime? dateFromFilter, DateTime? dateToFilter, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new event and persists it in the data store.
    /// </summary>
    /// <param name="event">The event to be created. It contains details such as title, description, start date, and end date.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the asynchronous operation.</param>
    /// <returns>Returns the created event with its assigned identifier.</returns>
    Task<Event> CreateAsync(Event @event, CancellationToken cancellationToken);
    
    /// <summary>
    /// Deletes an event based on the specified identifier.
    /// </summary>
    /// <param name="eventId">The unique identifier of the event to delete.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests during the operation.</param>
    /// <returns>A task that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(int eventId, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing event in the repository with the provided details.
    /// </summary>
    /// <param name="updatedEvent">An event object containing the updated details. The event's ID must match an existing event in the repository.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests during the update process.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the updated event if the operation is successful, or null if no matching event was found.
    /// </returns>
    Task<Event?> UpdateAsync(Event updatedEvent, CancellationToken cancellationToken);
}