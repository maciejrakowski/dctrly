using MediatR;

namespace dctrly.Application.Commands;

public class CreateAppointmentInvitationCommand : IRequest<int?>
{
    public int EventId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsAttending { get; set; }

    public CreateAppointmentInvitationCommand()
    {
    }

    public CreateAppointmentInvitationCommand(int eventId, string name, string email)
    {
        EventId = eventId;
        Name = name;
        Email = email;
    }
}