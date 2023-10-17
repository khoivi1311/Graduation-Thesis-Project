using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace learn_programming_services.Database.Migrations
{
    public partial class AddPracticesAndDiscussionsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discussions_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PracticeLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeLevels", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiscussionComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DiscussionId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussionComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscussionComments_Discussions_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "Discussions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscussionComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Practices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PracticeLevelId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Practices_PracticeLevels_PracticeLevelId",
                        column: x => x.PracticeLevelId,
                        principalTable: "PracticeLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Practices_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiscussionCommentActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DiscussionCommentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsLiked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDisliked = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussionCommentActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscussionCommentActions_DiscussionComments_DiscussionCommen~",
                        column: x => x.DiscussionCommentId,
                        principalTable: "DiscussionComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscussionCommentActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiscussionReplyComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DiscussionCommentId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussionReplyComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscussionReplyComments_DiscussionComments_DiscussionComment~",
                        column: x => x.DiscussionCommentId,
                        principalTable: "DiscussionComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscussionReplyComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PracticeHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CodeLanguageId = table.Column<int>(type: "int", nullable: false),
                    TestCase = table.Column<string>(type: "longtext", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CodeSubmitted = table.Column<string>(type: "longtext", nullable: false),
                    SubmittedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PracticeId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracticeHistories_CodeLanguages_CodeLanguageId",
                        column: x => x.CodeLanguageId,
                        principalTable: "CodeLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PracticeHistories_Practices_PracticeId",
                        column: x => x.PracticeId,
                        principalTable: "Practices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PracticeHistories_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PracticeTestCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Input = table.Column<string>(type: "longtext", nullable: false),
                    ExpectedOutput = table.Column<string>(type: "longtext", nullable: false),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PracticeId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeTestCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracticeTestCases_Practices_PracticeId",
                        column: x => x.PracticeId,
                        principalTable: "Practices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiscussionReplyCommentActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DiscussionReplyCommentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsLiked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDisliked = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussionReplyCommentActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscussionReplyCommentActions_DiscussionReplyComments_Discus~",
                        column: x => x.DiscussionReplyCommentId,
                        principalTable: "DiscussionReplyComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscussionReplyCommentActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "PracticeLevels",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[] { 1, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "Easy", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690) });

            migrationBuilder.InsertData(
                table: "PracticeLevels",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[] { 2, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "Medium", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690) });

            migrationBuilder.InsertData(
                table: "PracticeLevels",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[] { 3, new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690), "Hard", new DateTime(2023, 5, 22, 6, 50, 15, 143, DateTimeKind.Unspecified).AddTicks(8690) });

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionCommentActions_DiscussionCommentId",
                table: "DiscussionCommentActions",
                column: "DiscussionCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionCommentActions_UserId",
                table: "DiscussionCommentActions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionComments_AuthorId",
                table: "DiscussionComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionComments_DiscussionId",
                table: "DiscussionComments",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionReplyCommentActions_DiscussionReplyCommentId",
                table: "DiscussionReplyCommentActions",
                column: "DiscussionReplyCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionReplyCommentActions_UserId",
                table: "DiscussionReplyCommentActions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionReplyComments_AuthorId",
                table: "DiscussionReplyComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionReplyComments_DiscussionCommentId",
                table: "DiscussionReplyComments",
                column: "DiscussionCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_AuthorId",
                table: "Discussions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeHistories_AuthorId",
                table: "PracticeHistories",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeHistories_CodeLanguageId",
                table: "PracticeHistories",
                column: "CodeLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeHistories_PracticeId",
                table: "PracticeHistories",
                column: "PracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_Practices_AuthorId",
                table: "Practices",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Practices_PracticeLevelId",
                table: "Practices",
                column: "PracticeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeTestCases_PracticeId",
                table: "PracticeTestCases",
                column: "PracticeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscussionCommentActions");

            migrationBuilder.DropTable(
                name: "DiscussionReplyCommentActions");

            migrationBuilder.DropTable(
                name: "PracticeHistories");

            migrationBuilder.DropTable(
                name: "PracticeTestCases");

            migrationBuilder.DropTable(
                name: "DiscussionReplyComments");

            migrationBuilder.DropTable(
                name: "Practices");

            migrationBuilder.DropTable(
                name: "DiscussionComments");

            migrationBuilder.DropTable(
                name: "PracticeLevels");

            migrationBuilder.DropTable(
                name: "Discussions");
        }
    }
}
