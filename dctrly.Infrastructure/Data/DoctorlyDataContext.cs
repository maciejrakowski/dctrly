using dctrly.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dctrly.Infrastructure.Data;

public class DoctorlyDataContext : DbContext
{
    public DoctorlyDataContext(DbContextOptions<DoctorlyDataContext> options) : base(options)
    {
    }

    DbSet<Attendee> Attendees { get; set; }
    DbSet<Event> Events { get; set; }
}