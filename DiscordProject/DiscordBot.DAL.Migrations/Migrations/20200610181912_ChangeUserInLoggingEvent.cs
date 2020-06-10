using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscordBot.DAL.Migrations.Migrations
{
    public partial class ChangeUserInLoggingEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscordUserName",
                table: "LoggingEvent");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscordUserId",
                table: "LoggingEvent",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DiscordDisplayName",
                table: "LoggingEvent",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscordDisplayName",
                table: "LoggingEvent");

            migrationBuilder.AlterColumn<int>(
                name: "DiscordUserId",
                table: "LoggingEvent",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)");

            migrationBuilder.AddColumn<string>(
                name: "DiscordUserName",
                table: "LoggingEvent",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
