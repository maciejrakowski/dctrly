using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dctrly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventIdForAttendee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Attendees",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Attendees");
        }
    }
}
