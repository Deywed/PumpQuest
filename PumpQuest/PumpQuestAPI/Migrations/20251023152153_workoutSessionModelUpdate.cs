using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PumpQuestAPI.Migrations
{
    /// <inheritdoc />
    public partial class workoutSessionModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "WorkoutSessions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "WorkoutSessions");
        }
    }
}
