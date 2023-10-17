using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace learn_programming_services.Database.Migrations
{
    public partial class DeleteCourseObjectiveImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseObjectiveImages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseObjectiveImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: false),
                    ImageNumber = table.Column<int>(type: "int", nullable: false),
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
    }
}
