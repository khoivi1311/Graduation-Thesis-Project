using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace learn_programming_services.Database.Migrations
{
    public partial class AddLessonCodeSamplesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeSample",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CodeLanguage",
                table: "LessonHistories");

            migrationBuilder.AddColumn<int>(
                name: "CodeLanguageId",
                table: "LessonHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CodeLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Version = table.Column<string>(type: "longtext", nullable: false),
                    SubmitName = table.Column<string>(type: "longtext", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeLanguages", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LessonCodeSamples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CodeSample = table.Column<string>(type: "longtext", nullable: false),
                    CodeLanguageId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonCodeSamples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonCodeSamples_CodeLanguages_CodeLanguageId",
                        column: x => x.CodeLanguageId,
                        principalTable: "CodeLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonCodeSamples_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CodeLanguages",
                columns: new[] { "Id", "CreateDate", "Name", "SubmitName", "UpdateDate", "Version" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "C", "c", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "11.3.0" },
                    { 2, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "C++", "cpp", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "11.3.0" },
                    { 3, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "Java", "java", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "18.0.2" },
                    { 4, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "NodeJS", "nodejs", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "12.22.9" },
                    { 5, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "Octave", "octave", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "6.4.0" },
                    { 6, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "Pascal", "pascal", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "3.2.2" },
                    { 7, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "PHP", "php", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "8.1.2" },
                    { 8, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "Python 3", "python3", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "3.10.6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonHistories_CodeLanguageId",
                table: "LessonHistories",
                column: "CodeLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonCodeSamples_CodeLanguageId",
                table: "LessonCodeSamples",
                column: "CodeLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonCodeSamples_LessonId",
                table: "LessonCodeSamples",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonHistories_CodeLanguages_CodeLanguageId",
                table: "LessonHistories",
                column: "CodeLanguageId",
                principalTable: "CodeLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonHistories_CodeLanguages_CodeLanguageId",
                table: "LessonHistories");

            migrationBuilder.DropTable(
                name: "LessonCodeSamples");

            migrationBuilder.DropTable(
                name: "CodeLanguages");

            migrationBuilder.DropIndex(
                name: "IX_LessonHistories_CodeLanguageId",
                table: "LessonHistories");

            migrationBuilder.DropColumn(
                name: "CodeLanguageId",
                table: "LessonHistories");

            migrationBuilder.AddColumn<string>(
                name: "CodeSample",
                table: "Lessons",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "CodeLanguage",
                table: "LessonHistories",
                type: "longtext",
                nullable: false);
        }
    }
}
