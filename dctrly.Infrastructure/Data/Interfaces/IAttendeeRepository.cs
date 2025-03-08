using dctrly.Domain.Entities;

namespace dctrly.Infrastructure.Data.Interfaces;

public interface IAttendeeRepository
{
    Task<int> CreateAppointmentInvitationAsync(Attendee attendee);
    Task<Attendee?> GetAttendeeAsync(int id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);

    Task<IEnumerable<Attendee>> GetAttendeesByEventIdAsync(int eventId,
        CancellationToken cancellationToken);
}