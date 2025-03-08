using System.Threading;
using System.Threading.Tasks;
using dctrly.Application.Commands;
using dctrly.Application.Commands.Handlers;
using dctrly.Domain.Entities;
using dctrly.Infrastructure.Data.Interfaces;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace dctrly.Application.Test;

public class AcceptAppointmentCommandHandlerTests
{
    private readonly Mock<IAttendeeRepository> _attendeeRepositoryMock;

    private readonly AcceptAppointmentCommandHandler _handler;

    public AcceptAppointmentCommandHandlerTests()
    {
        _attendeeRepositoryMock = new Mock<IAttendeeRepository>();

        _handler = new AcceptAppointmentCommandHandler(_attendeeRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturn_Success_WhenAppointmentExists()
    {
        // Arrange
        var command = new AcceptAppointmentCommand
        {
            AttendeeId = 1
        };

        var attendee = new Attendee { Id = command.AttendeeId };
        
        // Mock repository behavior
        _attendeeRepositoryMock
            .Setup(repo => repo.GetAttendeeAsync(command.AttendeeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(attendee); // Mock appointment object

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        attendee.IsAttending.ShouldBeTrue(); // Assert that appointment was accepted

        // Verify mock interactions
        _attendeeRepositoryMock.Verify(repo => repo.GetAttendeeAsync(command.AttendeeId, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenAttendeeNotFound()
    {
        // Arrange
        var command = new AcceptAppointmentCommand
        {
            AttendeeId = 1
        };

        _attendeeRepositoryMock
            .Setup(repo => repo.GetAttendeeAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Attendee)null); 

        // Act & Assert
        await Should.ThrowAsync<Exception>(async () =>
        {
            await _handler.Handle(command, CancellationToken.None);
        });
    }
}