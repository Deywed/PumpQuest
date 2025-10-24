using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PumpQuestAPI.Migrations
{
    /// <inheritdoc />
    public partial class rewards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reward100",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Reward200",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Reward300",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Reward400",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "Reward100",
                table: "UserStatistics",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reward200",
                table: "UserStatistics",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reward300",
                table: "UserStatistics",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reward400",
                table: "UserStatistics",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reward100",
                table: "UserStatistics");

            migrationBuilder.DropColumn(
                name: "Reward200",
                table: "UserStatistics");

            migrationBuilder.DropColumn(
                name: "Reward300",
                table: "UserStatistics");

            migrationBuilder.DropColumn(
                name: "Reward400",
                table: "UserStatistics");

            migrationBuilder.AddColumn<bool>(
                name: "Reward100",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reward200",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reward300",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reward400",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
