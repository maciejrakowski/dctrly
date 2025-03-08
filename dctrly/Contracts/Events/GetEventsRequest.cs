namespace dctrly.Contracts.Events;

public class GetEventsRequest
{
    public string? TitleFilter { get; set; }
    public string? DescriptionFilter { get; set; }
    public DateTime? DateFromFilter { get; set; }
    public DateTime? DateToFilter { get; set; }
}