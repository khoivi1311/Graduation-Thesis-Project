using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace learn_programming_services.Database.Migrations
{
    public partial class UpdateCommentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDislike",
                table: "LessonReplyComments");

            migrationBuilder.DropColumn(
                name: "NumberOfLike",
                table: "LessonReplyComments");

            migrationBuilder.DropColumn(
                name: "NumberOfDislike",
                table: "LessonComments");

            migrationBuilder.DropColumn(
                name: "NumberOfLike",
                table: "LessonComments");

            migrationBuilder.DropColumn(
                name: "NumberOfDislike",
                table: "CourseReplyComments");

            migrationBuilder.DropColumn(
                name: "NumberOfLike",
                table: "CourseReplyComments");

            migrationBuilder.DropColumn(
                name: "NumberOfDislike",
                table: "CourseComments");

            migrationBuilder.DropColumn(
                name: "NumberOfLike",
                table: "CourseComments");

            migrationBuilder.CreateTable(
                name: "CourseCommentActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CourseCommentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsLiked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDisliked = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCommentActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseCommentActions_CourseComments_CourseCommentId",
                        column: x => x.CourseCommentId,
                        principalTable: "CourseComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCommentActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseReplyCommentActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CourseReplyCommentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsLiked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDisliked = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseReplyCommentActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseReplyCommentActions_CourseReplyComments_CourseReplyCom~",
                        column: x => x.CourseReplyCommentId,
                        principalTable: "CourseReplyComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseReplyCommentActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LessonCommentActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LessonCommentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsLiked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDisliked = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonCommentActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonCommentActions_LessonComments_LessonCommentId",
                        column: x => x.LessonCommentId,
                        principalTable: "LessonComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonCommentActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LessonReplyCommentActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LessonReplyCommentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsLiked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDisliked = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonReplyCommentActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonReplyCommentActions_LessonReplyComments_LessonReplyCom~",
                        column: x => x.LessonReplyCommentId,
                        principalTable: "LessonReplyComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonReplyCommentActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCommentActions_CourseCommentId",
                table: "CourseCommentActions",
                column: "CourseCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCommentActions_UserId",
                table: "CourseCommentActions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseReplyCommentActions_CourseReplyCommentId",
                table: "CourseReplyCommentActions",
                column: "CourseReplyCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseReplyCommentActions_UserId",
                table: "CourseReplyCommentActions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonCommentActions_LessonCommentId",
                table: "LessonCommentActions",
                column: "LessonCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonCommentActions_UserId",
                table: "LessonCommentActions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonReplyCommentActions_LessonReplyCommentId",
                table: "LessonReplyCommentActions",
                column: "LessonReplyCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonReplyCommentActions_UserId",
                table: "LessonReplyCommentActions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseCommentActions");

            migrationBuilder.DropTable(
                name: "CourseReplyCommentActions");

            migrationBuilder.DropTable(
                name: "LessonCommentActions");

            migrationBuilder.DropTable(
                name: "LessonReplyCommentActions");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDislike",
                table: "LessonReplyComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLike",
                table: "LessonReplyComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDislike",
                table: "LessonComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLike",
                table: "LessonComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDislike",
                table: "CourseReplyComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLike",
                table: "CourseReplyComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDislike",
                table: "CourseComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLike",
                table: "CourseComments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
