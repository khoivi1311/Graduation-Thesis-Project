using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace learn_programming_services.Database.Migrations
{
    public partial class AddContestsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContestStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestStatuses", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Information = table.Column<string>(type: "longtext", nullable: false),
                    Location = table.Column<string>(type: "longtext", nullable: false),
                    VerificationCode = table.Column<string>(type: "longtext", nullable: false),
                    ContestStatusId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contests_ContestStatuses_ContestStatusId",
                        column: x => x.ContestStatusId,
                        principalTable: "ContestStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contests_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContestTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ContestId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestTasks_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestTasks_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRegisterContests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ContestId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EnrolledDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FinishedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegisterContests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRegisterContests_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRegisterContests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContestTaskCodeLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CodeLanguageId = table.Column<int>(type: "int", nullable: false),
                    ContestTaskId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestTaskCodeLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestTaskCodeLanguages_CodeLanguages_CodeLanguageId",
                        column: x => x.CodeLanguageId,
                        principalTable: "CodeLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestTaskCodeLanguages_ContestTasks_ContestTaskId",
                        column: x => x.ContestTaskId,
                        principalTable: "ContestTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContestTaskHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CodeLanguageId = table.Column<int>(type: "int", nullable: false),
                    TestCase = table.Column<string>(type: "longtext", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CodeSubmitted = table.Column<string>(type: "longtext", nullable: false),
                    SubmittedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ContestTaskId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestTaskHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestTaskHistories_CodeLanguages_CodeLanguageId",
                        column: x => x.CodeLanguageId,
                        principalTable: "CodeLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestTaskHistories_ContestTasks_ContestTaskId",
                        column: x => x.ContestTaskId,
                        principalTable: "ContestTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestTaskHistories_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContestTaskTestCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Input = table.Column<string>(type: "longtext", nullable: false),
                    ExpectedOutput = table.Column<string>(type: "longtext", nullable: false),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ContestTaskId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestTaskTestCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestTaskTestCases_ContestTasks_ContestTaskId",
                        column: x => x.ContestTaskId,
                        principalTable: "ContestTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ContestStatuses",
                columns: new[] { "Id", "CreateDate", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "The new contest will come into next days", "Comming soon", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690) },
                    { 2, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "The contest open registration for participants", "Open registration", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690) },
                    { 3, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "The contest will close registration one day before the start date", "Closed registration", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690) },
                    { 4, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "The contest is on going", "On going", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690) },
                    { 5, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "The contest had finished", "Finished", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contests_AuthorId",
                table: "Contests",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contests_ContestStatusId",
                table: "Contests",
                column: "ContestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTaskCodeLanguages_CodeLanguageId",
                table: "ContestTaskCodeLanguages",
                column: "CodeLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTaskCodeLanguages_ContestTaskId",
                table: "ContestTaskCodeLanguages",
                column: "ContestTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTaskHistories_AuthorId",
                table: "ContestTaskHistories",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTaskHistories_CodeLanguageId",
                table: "ContestTaskHistories",
                column: "CodeLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTaskHistories_ContestTaskId",
                table: "ContestTaskHistories",
                column: "ContestTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTasks_AuthorId",
                table: "ContestTasks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTasks_ContestId",
                table: "ContestTasks",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTaskTestCases_ContestTaskId",
                table: "ContestTaskTestCases",
                column: "ContestTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegisterContests_ContestId",
                table: "UserRegisterContests",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegisterContests_UserId",
                table: "UserRegisterContests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContestTaskCodeLanguages");

            migrationBuilder.DropTable(
                name: "ContestTaskHistories");

            migrationBuilder.DropTable(
                name: "ContestTaskTestCases");

            migrationBuilder.DropTable(
                name: "UserRegisterContests");

            migrationBuilder.DropTable(
                name: "ContestTasks");

            migrationBuilder.DropTable(
                name: "Contests");

            migrationBuilder.DropTable(
                name: "ContestStatuses");
        }
    }
}
