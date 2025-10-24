using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PumpQuestAPI.Migrations
{
    /// <inheritdoc />
    public partial class mdmdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_Users_BuddyUid",
                table: "WorkoutSessions");

            migrationBuilder.AlterColumn<string>(
                name: "BuddyUid",
                table: "WorkoutSessions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_Users_BuddyUid",
                table: "WorkoutSessions",
                column: "BuddyUid",
                principalTable: "Users",
                principalColumn: "Uid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_Users_BuddyUid",
                table: "WorkoutSessions");

            migrationBuilder.AlterColumn<string>(
                name: "BuddyUid",
                table: "WorkoutSessions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_Users_BuddyUid",
                table: "WorkoutSessions",
                column: "BuddyUid",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
