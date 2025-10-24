using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PumpQuestAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixxx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Coaches_CoachId",
                table: "Workouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Users_UserUid",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_UserUid",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "UserUid",
                table: "Workouts");

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "Workouts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "CoachUid",
                table: "Workouts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_CoachUid",
                table: "Workouts",
                column: "CoachUid");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Coaches_CoachId",
                table: "Workouts",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Users_CoachUid",
                table: "Workouts",
                column: "CoachUid",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Coaches_CoachId",
                table: "Workouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Users_CoachUid",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_CoachUid",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "CoachUid",
                table: "Workouts");

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "Workouts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserUid",
                table: "Workouts",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserUid",
                table: "Workouts",
                column: "UserUid");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Coaches_CoachId",
                table: "Workouts",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Users_UserUid",
                table: "Workouts",
                column: "UserUid",
                principalTable: "Users",
                principalColumn: "Uid");
        }
    }
}
