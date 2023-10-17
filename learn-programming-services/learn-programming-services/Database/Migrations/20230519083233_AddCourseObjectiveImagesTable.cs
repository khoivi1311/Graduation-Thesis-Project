using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace learn_programming_services.Database.Migrations
{
    public partial class AddCourseObjectiveImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Courses",
                type: "longtext",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "CourseObjectiveImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ImageNumber = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseObjectiveImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseObjectiveImages_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CourseObjectiveImages_CourseId",
                table: "CourseObjectiveImages",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseObjectiveImages");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Courses");
        }
    }
}
