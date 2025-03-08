using dctrly.Domain.Entities;
using dctrly.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dctrly.Infrastructure.Data.Repositories;

internal class AttendeeRepository(DoctorlyDataContext context) : IAttendeeRepository
{
    public async Task<int> CreateAppointmentInvitationAsync(Attendee attendee)
    {
        await context.Attendees.AddAsync(attendee);
        await context.SaveChangesAsync();

        return attendee.Id;
    }

    public async Task<Attendee?> GetAttendeeAsync(int id, CancellationToken cancellationToken)
    {
        var result = await context.Attendees.FindAsync([id], cancellationToken: cancellationToken);
        return result;
    }

    public async Task<IEnumerable<Attendee>> GetAttendeesByEventIdAsync(int eventId,
        CancellationToken cancellationToken)
    {
        var result = await context.Attendees
            .Where(x => x.EventId == eventId)
            .ToListAsync(cancellationToken);

        return result;
    }
    
    
    // Usually I've put this in base repo with generic CRUD methods
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}