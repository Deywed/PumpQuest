using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PumpQuestAPI.Migrations
{
    /// <inheritdoc />
    public partial class ddd11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStatistics_Users_Uid",
                table: "UserStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStatistics",
                table: "UserStatistics");

            migrationBuilder.RenameColumn(
                name: "Uid",
                table: "UserStatistics",
                newName: "UserUid");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserStatistics",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Xp",
                table: "UserStatistics",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStatistics",
                table: "UserStatistics",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserStatistics_UserUid",
                table: "UserStatistics",
                column: "UserUid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStatistics_Users_UserUid",
                table: "UserStatistics",
                column: "UserUid",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStatistics_Users_UserUid",
                table: "UserStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStatistics",
                table: "UserStatistics");

            migrationBuilder.DropIndex(
                name: "IX_UserStatistics_UserUid",
                table: "UserStatistics");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserStatistics");

            migrationBuilder.DropColumn(
                name: "Xp",
                table: "UserStatistics");

            migrationBuilder.RenameColumn(
                name: "UserUid",
                table: "UserStatistics",
                newName: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStatistics",
                table: "UserStatistics",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserStatistics_Users_Uid",
                table: "UserStatistics",
                column: "Uid",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
