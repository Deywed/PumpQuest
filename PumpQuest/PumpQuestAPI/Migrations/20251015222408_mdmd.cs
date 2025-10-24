using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PumpQuestAPI.Migrations
{
    /// <inheritdoc />
    public partial class mdmd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Xp",
                table: "UserStatistics");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "UserStatistics",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorUid = table.Column<string>(type: "text", nullable: false),
                    BuddyUid = table.Column<string>(type: "text", nullable: false),
                    WorkoutId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GymId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_Users_BuddyUid",
                        column: x => x.BuddyUid,
                        principalTable: "Users",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_Users_CreatorUid",
                        column: x => x.CreatorUid,
                        principalTable: "Users",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_BuddyUid",
                table: "WorkoutSessions",
                column: "BuddyUid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_CreatorUid",
                table: "WorkoutSessions",
                column: "CreatorUid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_GymId",
                table: "WorkoutSessions",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_WorkoutId",
                table: "WorkoutSessions",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutSessions");

            migrationBuilder.AlterColumn<double>(
                name: "Age",
                table: "UserStatistics",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Xp",
                table: "UserStatistics",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
