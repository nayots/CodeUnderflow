using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CodeUnderflow.Data.Migrations
{
    public partial class QuestionEditDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "Questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "Questions");
        }
    }
}