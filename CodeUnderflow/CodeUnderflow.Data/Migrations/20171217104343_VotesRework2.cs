using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeUnderflow.Data.Migrations
{
    public partial class VotesRework2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpvote",
                table: "Votes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUpvote",
                table: "Votes",
                nullable: false,
                defaultValue: false);
        }
    }
}