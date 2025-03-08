using dctrly.Domain.Entities;
using MediatR;

namespace dctrly.Application.Queries;

public class GetEventsQuery : IRequest<IEnumerable<Event>>
{
    public string? TitleFilter { get; set; }
    public string? DescriptionFilter { get; set; }
    public DateTime? DateFromFilter { get; set; }
    public DateTime? DateToFilter { get; set; }

    public GetEventsQuery()
    {
    }

    public GetEventsQuery(string? titleFilter, string? descriptionFilter, DateTime? dateFromFilter, DateTime? dateToFilter)
    {
        TitleFilter = titleFilter;
        DescriptionFilter = descriptionFilter;
        DateFromFilter = dateFromFilter;
        DateToFilter = dateToFilter;
    }
}