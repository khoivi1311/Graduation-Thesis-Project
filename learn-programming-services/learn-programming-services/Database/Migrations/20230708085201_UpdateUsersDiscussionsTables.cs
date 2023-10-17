using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learn_programming_services.Database.Migrations
{
    public partial class UpdateUsersDiscussionsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Users",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Discussions",
                type: "longtext",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Discussions");
        }
    }
}
