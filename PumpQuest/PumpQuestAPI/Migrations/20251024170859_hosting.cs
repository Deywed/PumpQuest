using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PumpQuestAPI.Migrations
{
    /// <inheritdoc />
    public partial class hosting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Coaches_CoachId",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_CoachId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "Workouts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "Workouts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Xp = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_CoachId",
                table: "Workouts",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Coaches_CoachId",
                table: "Workouts",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id");
        }
    }
}
