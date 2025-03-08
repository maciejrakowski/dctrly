namespace dctrly.Domain.Entities;

public class Attendee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
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