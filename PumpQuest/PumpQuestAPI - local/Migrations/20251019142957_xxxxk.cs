using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PumpQuestAPI.Migrations
{
    /// <inheritdoc />
    public partial class xxxxk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserUid",
                table: "Workouts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserUid",
                table: "Workouts",
                column: "UserUid");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Users_UserUid",
                table: "Workouts",
                column: "UserUid",
                principalTable: "Users",
                principalColumn: "Uid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Users_UserUid",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_UserUid",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "UserUid",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
