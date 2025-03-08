using MediatR;

namespace dctrly.Application.Commands;

public class DeleteEventCommand : IRequest
{
    public int Id { get; set; }
}