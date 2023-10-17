using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learn_programming_services.Database.Migrations
{
    public partial class UpdateDiscussionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Discussions",
                type: "longtext",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Discussions");
        }
    }
}
