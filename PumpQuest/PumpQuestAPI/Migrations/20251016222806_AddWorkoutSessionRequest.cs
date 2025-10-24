using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PumpQuestAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutSessionRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkoutSessionRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderUid = table.Column<string>(type: "text", nullable: false),
                    ReceiverUid = table.Column<string>(type: "text", nullable: false),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutSessionRequests_Users_ReceiverUid",
                        column: x => x.ReceiverUid,
                        principalTable: "Users",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutSessionRequests_Users_SenderUid",
                        column: x => x.SenderUid,
                        principalTable: "Users",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutSessionRequests_WorkoutSessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "WorkoutSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessionRequests_ReceiverUid",
                table: "WorkoutSessionRequests",
                column: "ReceiverUid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessionRequests_SenderUid",
                table: "WorkoutSessionRequests",
                column: "SenderUid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessionRequests_SessionId",
                table: "WorkoutSessionRequests",
                column: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutSessionRequests");
        }
    }
}
