using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace learn_programming_services.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseLevels",
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
                    table.PrimaryKey("PK_CourseLevels", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Permissions",
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
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
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
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true),
                    LastName = table.Column<string>(type: "longtext", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    UserName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Objective = table.Column<string>(type: "longtext", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CourseLevelId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CourseLevels_CourseLevelId",
                        column: x => x.CourseLevelId,
                        principalTable: "CourseLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AccessToken = table.Column<string>(type: "longtext", nullable: false),
                    RefreshToken = table.Column<string>(type: "longtext", nullable: false),
                    IsUsed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsRevoked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IssuedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    NumberOfLike = table.Column<int>(type: "int", nullable: false),
                    NumberOfDislike = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseComments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserStudyCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStudyCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStudyCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStudyCourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    CodeSample = table.Column<string>(type: "longtext", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseReplyComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    NumberOfLike = table.Column<int>(type: "int", nullable: false),
                    NumberOfDislike = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CourseCommentId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseReplyComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseReplyComments_CourseComments_CourseCommentId",
                        column: x => x.CourseCommentId,
                        principalTable: "CourseComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseReplyComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LessonComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    NumberOfLike = table.Column<int>(type: "int", nullable: false),
                    NumberOfDislike = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonComments_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LessonHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CodeLanguage = table.Column<string>(type: "longtext", nullable: false),
                    TestCase = table.Column<string>(type: "longtext", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CodeSubmitted = table.Column<string>(type: "longtext", nullable: false),
                    SubmittedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonHistories_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonHistories_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LessonTestCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Input = table.Column<string>(type: "longtext", nullable: false),
                    ExpectedOutput = table.Column<string>(type: "longtext", nullable: false),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTestCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonTestCases_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLearnedLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLearnedLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLearnedLessons_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLearnedLessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLearnedLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLearnedLessons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LessonReplyComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    NumberOfLike = table.Column<int>(type: "int", nullable: false),
                    NumberOfDislike = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LessonCommentId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonReplyComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonReplyComments_LessonComments_LessonCommentId",
                        column: x => x.LessonCommentId,
                        principalTable: "LessonComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonReplyComments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CourseLevels",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified), "Basic knowledge", new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified), "General knowledge", new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified), "Specialized knowledge", new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreateDate", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified), null, "USER MANAGEMENT", new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified), null, "POST COURSE", new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified), null, "CREATE EXAMINATION", new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified), null, "POST PRACTICE", new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified), null, "LEARNING", new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified), null, "TAKE EXAMINATION", new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified), null, "ADMIN", new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified), null, "AUTHOR", new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified), null, "STUDENT", new DateTime(2023, 4, 4, 11, 20, 5, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_CourseId",
                table: "Chapters",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_AuthorId",
                table: "CourseComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_CourseId",
                table: "CourseComments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseReplyComments_AuthorId",
                table: "CourseReplyComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseReplyComments_CourseCommentId",
                table: "CourseReplyComments",
                column: "CourseCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AuthorId",
                table: "Courses",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseLevelId",
                table: "Courses",
                column: "CourseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonComments_AuthorId",
                table: "LessonComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonComments_LessonId",
                table: "LessonComments",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonHistories_AuthorId",
                table: "LessonHistories",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonHistories_LessonId",
                table: "LessonHistories",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonReplyComments_AuthorId",
                table: "LessonReplyComments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonReplyComments_LessonCommentId",
                table: "LessonReplyComments",
                column: "LessonCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_AuthorId",
                table: "Lessons",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ChapterId",
                table: "Lessons",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTestCases_LessonId",
                table: "LessonTestCases",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLearnedLessons_ChapterId",
                table: "UserLearnedLessons",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLearnedLessons_CourseId",
                table: "UserLearnedLessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLearnedLessons_LessonId",
                table: "UserLearnedLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLearnedLessons_UserId",
                table: "UserLearnedLessons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_PermissionId",
                table: "UserPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UserId",
                table: "UserPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserStudyCourses_CourseId",
                table: "UserStudyCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStudyCourses_UserId",
                table: "UserStudyCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseReplyComments");

            migrationBuilder.DropTable(
                name: "LessonHistories");

            migrationBuilder.DropTable(
                name: "LessonReplyComments");

            migrationBuilder.DropTable(
                name: "LessonTestCases");

            migrationBuilder.DropTable(
                name: "UserLearnedLessons");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "UserStudyCourses");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "CourseComments");

            migrationBuilder.DropTable(
                name: "LessonComments");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseLevels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
