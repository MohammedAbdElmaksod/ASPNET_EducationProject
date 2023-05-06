using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationProject.Migrations
{
    /// <inheritdoc />
    public partial class AssignmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbAssignmentsDone",
                columns: table => new
                {
                    MatrialId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: true),
                    imgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lesson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    semester = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chapter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignmentId = table.Column<int>(type: "int", nullable: true),
                    teacherId = table.Column<int>(type: "int", nullable: true),
                    levelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbAssignmentDones_TbAssignmentLinks",
                        column: x => x.AssignmentId,
                        principalTable: "TbAssignmentLinks",
                        principalColumn: "AssignmentId");
                    table.ForeignKey(
                        name: "FK_TbAssignment_TbMatrial",
                        column: x => x.MatrialId,
                        principalTable: "TbMatrial",
                        principalColumn: "MatrialID");
                    table.ForeignKey(
                        name: "FK_TbAssignmentsDone_TbLevel_levelId",
                        column: x => x.levelId,
                        principalTable: "TbLevel",
                        principalColumn: "LevelId");
                    table.ForeignKey(
                        name: "FK_TbAssignmentsDone_TbTeacher_teacherId",
                        column: x => x.teacherId,
                        principalTable: "TbTeacher",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignmentsDone_AssignmentId",
                table: "TbAssignmentsDone",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignmentsDone_levelId",
                table: "TbAssignmentsDone",
                column: "levelId");

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignmentsDone_MatrialId",
                table: "TbAssignmentsDone",
                column: "MatrialId");

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignmentsDone_teacherId",
                table: "TbAssignmentsDone",
                column: "teacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbAssignmentsDone");
        }
    }
}
