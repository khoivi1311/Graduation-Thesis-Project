using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learn_programming_services.Database.Migrations
{
    public partial class UpdateCoursesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Courses",
                type: "longtext",
                nullable: false);
        }
    }
}
