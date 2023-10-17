using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learn_programming_services.Database.Migrations
{
    public partial class UpdateUserStudyCoursesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "UserStudyCourses",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "UserStudyCourses");
        }
    }
}
