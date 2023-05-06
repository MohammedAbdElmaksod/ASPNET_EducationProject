using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationProject.Migrations
{
    /// <inheritdoc />
    public partial class title : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbLevel",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    YearLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbLevel", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "TbMatrialTbStudent",
                columns: table => new
                {
                    MatrialId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbMatrialTbStudent", x => new { x.MatrialId, x.StudentId });
                });

            migrationBuilder.CreateTable(
                name: "TbMatrialTbTeacher",
                columns: table => new
                {
                    MatrialId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbMatrialTbTeacher", x => new { x.MatrialId, x.TeacherId });
                });

            migrationBuilder.CreateTable(
                name: "TbMatrialTbVideo",
                columns: table => new
                {
                    MatrialId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbMatrialTbVideo", x => new { x.MatrialId, x.VideoId });
                });

            migrationBuilder.CreateTable(
                name: "TbTeacher",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTeacher", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "TbMatrial",
                columns: table => new
                {
                    MatrialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatrialName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbMatrial", x => x.MatrialID);
                    table.ForeignKey(
                        name: "FK_TbMatrial_TbLevel",
                        column: x => x.LevelId,
                        principalTable: "TbLevel",
                        principalColumn: "LevelId");
                });

            migrationBuilder.CreateTable(
                name: "TbStudent",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbStudent", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_TbStudent_TbLevel",
                        column: x => x.LevelId,
                        principalTable: "TbLevel",
                        principalColumn: "LevelId");
                });

            migrationBuilder.CreateTable(
                name: "TbVideos",
                columns: table => new
                {
                    VideoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbVideos", x => x.VideoID);
                    table.ForeignKey(
                        name: "FK_TbVideos_TbLevel",
                        column: x => x.LevelId,
                        principalTable: "TbLevel",
                        principalColumn: "LevelId");
                });

            migrationBuilder.CreateTable(
                name: "TbMatrialTeacher",
                columns: table => new
                {
                    MatrialID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbMatrialTeacher", x => new { x.MatrialID, x.TeacherID });
                    table.ForeignKey(
                        name: "FK_TbMatrialTeacher_TbMatrial",
                        column: x => x.MatrialID,
                        principalTable: "TbMatrial",
                        principalColumn: "MatrialID");
                    table.ForeignKey(
                        name: "FK_TbMatrialTeacher_TbTeacher",
                        column: x => x.TeacherID,
                        principalTable: "TbTeacher",
                        principalColumn: "TeacherID");
                });

            migrationBuilder.CreateTable(
                name: "StudentMatrial",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    MatrialID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMatrial", x => new { x.StudentID, x.MatrialID });
                    table.ForeignKey(
                        name: "FK_StudentMatrial_TbMatrial",
                        column: x => x.MatrialID,
                        principalTable: "TbMatrial",
                        principalColumn: "MatrialID");
                    table.ForeignKey(
                        name: "FK_StudentMatrial_TbStudent",
                        column: x => x.StudentID,
                        principalTable: "TbStudent",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateTable(
                name: "TbAssignment",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    MatrialID = table.Column<int>(type: "int", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbAssignment", x => new { x.StudentID, x.MatrialID });
                    table.ForeignKey(
                        name: "FK_TbAssignment_TbLevel",
                        column: x => x.LevelId,
                        principalTable: "TbLevel",
                        principalColumn: "LevelId");
                    table.ForeignKey(
                        name: "FK_TbAssignment_TbMatrial",
                        column: x => x.MatrialID,
                        principalTable: "TbMatrial",
                        principalColumn: "MatrialID");
                    table.ForeignKey(
                        name: "FK_TbAssignment_TbStudent",
                        column: x => x.StudentID,
                        principalTable: "TbStudent",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateTable(
                name: "TbCodes",
                columns: table => new
                {
                    CodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCodes", x => x.CodeID);
                    table.ForeignKey(
                        name: "FK_TbCodes_TbLevel",
                        column: x => x.LevelId,
                        principalTable: "TbLevel",
                        principalColumn: "LevelId");
                    table.ForeignKey(
                        name: "FK_TbCodes_TbStudent",
                        column: x => x.StudentID,
                        principalTable: "TbStudent",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateTable(
                name: "MatrialVideo",
                columns: table => new
                {
                    MatrialID = table.Column<int>(type: "int", nullable: false),
                    VideoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatrialVideo", x => new { x.MatrialID, x.VideoID });
                    table.ForeignKey(
                        name: "FK_MatrialVideo_TbMatrial",
                        column: x => x.MatrialID,
                        principalTable: "TbMatrial",
                        principalColumn: "MatrialID");
                    table.ForeignKey(
                        name: "FK_MatrialVideo_TbVideos",
                        column: x => x.VideoID,
                        principalTable: "TbVideos",
                        principalColumn: "VideoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatrialVideo_VideoID",
                table: "MatrialVideo",
                column: "VideoID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMatrial_MatrialID",
                table: "StudentMatrial",
                column: "MatrialID");

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignment_LevelId",
                table: "TbAssignment",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignment_MatrialID",
                table: "TbAssignment",
                column: "MatrialID");

            migrationBuilder.CreateIndex(
                name: "IX_TbCodes_LevelId",
                table: "TbCodes",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TbCodes_StudentID",
                table: "TbCodes",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_TbMatrial_LevelId",
                table: "TbMatrial",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TbMatrialTeacher_TeacherID",
                table: "TbMatrialTeacher",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_TbStudent_LevelId",
                table: "TbStudent",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TbVideos_LevelId",
                table: "TbVideos",
                column: "LevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatrialVideo");

            migrationBuilder.DropTable(
                name: "StudentMatrial");

            migrationBuilder.DropTable(
                name: "TbAssignment");

            migrationBuilder.DropTable(
                name: "TbCodes");

            migrationBuilder.DropTable(
                name: "TbMatrialTbStudent");

            migrationBuilder.DropTable(
                name: "TbMatrialTbTeacher");

            migrationBuilder.DropTable(
                name: "TbMatrialTbVideo");

            migrationBuilder.DropTable(
                name: "TbMatrialTeacher");

            migrationBuilder.DropTable(
                name: "TbVideos");

            migrationBuilder.DropTable(
                name: "TbStudent");

            migrationBuilder.DropTable(
                name: "TbMatrial");

            migrationBuilder.DropTable(
                name: "TbTeacher");

            migrationBuilder.DropTable(
                name: "TbLevel");
        }
    }
}
