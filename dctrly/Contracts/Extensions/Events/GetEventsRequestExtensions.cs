using dctrly.Application.Queries;
using dctrly.Contracts.Events;

namespace dctrly.Contracts.Extensions.Events;

public static class GetEventsRequestExtensions
{
    public static GetEventsQuery ToGetEventsQuery(this GetEventsRequest request)
    {
        return new GetEventsQuery(request.TitleFilter, request.DescriptionFilter, request.DateFromFilter, request.DateToFilter);
    }
}