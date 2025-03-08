using System.ComponentModel.DataAnnotations;

namespace dctrly.Domain.Entities;

public class Attendee
{
    public int Id { get; set; }
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public bool IsAttending { get; set; }

    public Attendee()
    {
        // EF Core requires a default constructor
    }

    public Attendee(string name, string email)
    {
        Name = name;
        Email = email;
    }
}