using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathWizApi.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizTypeAndTotalTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuizType",
                table: "LeaderboardEntries",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTime",
                table: "LeaderboardEntries",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizType",
                table: "LeaderboardEntries");

            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "LeaderboardEntries");
        }
    }
}
