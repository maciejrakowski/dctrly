using System.ComponentModel.DataAnnotations;

namespace dctrly.Domain.Entities;

public class Event
{
    public int Id { get; set; }
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;
    [StringLength(2000)]
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Event()
    {
        // EF Core requires a default constructor
    }

    public Event(string title, string? description, DateTime startDate, DateTime endDate)
    {
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Event(int id, string title, string? description, DateTime startDate, DateTime endDate)
    {
        Id = id;
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
    }
}