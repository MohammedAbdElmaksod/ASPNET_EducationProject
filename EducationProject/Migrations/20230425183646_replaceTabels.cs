using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationProject.Migrations
{
    /// <inheritdoc />
    public partial class replaceTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbAssignmentDone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbAssignmentDone",
                columns: table => new
                {
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MatrialID = table.Column<int>(type: "int", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: true),
                    levelId = table.Column<int>(type: "int", nullable: false),
                    teacherId = table.Column<int>(type: "int", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    chapter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lesson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    semester = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbAssignment", x => new { x.StudentID, x.MatrialID });
                    table.ForeignKey(
                        name: "FK_TbAssignmentDone_TbAssignmentLinks",
                        column: x => x.AssignmentId,
                        principalTable: "TbAssignmentLinks",
                        principalColumn: "AssignmentId");
                    table.ForeignKey(
                        name: "FK_TbAssignmentDone_TbLevel_levelId",
                        column: x => x.levelId,
                        principalTable: "TbLevel",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbAssignmentDone_TbTeacher_teacherId",
                        column: x => x.teacherId,
                        principalTable: "TbTeacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignment_MatrialID",
                table: "TbAssignmentDone",
                column: "MatrialID");

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignmentDone_AssignmentId",
                table: "TbAssignmentDone",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignmentDone_levelId",
                table: "TbAssignmentDone",
                column: "levelId");

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignmentDone_teacherId",
                table: "TbAssignmentDone",
                column: "teacherId");
        }
    }
}
