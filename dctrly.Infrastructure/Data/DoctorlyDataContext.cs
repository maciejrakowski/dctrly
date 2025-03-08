using dctrly.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dctrly.Infrastructure.Data;

public class DoctorlyDataContext : DbContext
{
    public DoctorlyDataContext(DbContextOptions<DoctorlyDataContext> options) : base(options)
    {
    }

    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<Event> Events { get; set; }
}