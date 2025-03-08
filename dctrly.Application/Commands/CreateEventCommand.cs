using MediatR;

namespace dctrly.Application.Commands;

public class CreateEventCommand : IRequest<int>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public CreateEventCommand()
    {
    }

    public CreateEventCommand(string name, string? description, DateTime startDate, DateTime endDate)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
    }
}