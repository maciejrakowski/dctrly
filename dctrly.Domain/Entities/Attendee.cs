using System.ComponentModel.DataAnnotations;

namespace dctrly.Domain.Entities;

public class Attendee
{
    public int Id { get; set; }
    public int EventId { get; set; }
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public bool IsAttending { get; set; }

    public Attendee()
    {
        // EF Core requires a default constructor
    }

    public Attendee(int eventId, string name, string email)
    {
        EventId = eventId;
        Name = name;
        Email = email;
    }
}