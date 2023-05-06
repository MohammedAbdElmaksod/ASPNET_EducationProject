using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationProject.Migrations
{
    /// <inheritdoc />
    public partial class addRelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "levelId",
                table: "TbAssignmentDone",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "teacherId",
                table: "TbAssignmentDone",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignmentDone_levelId",
                table: "TbAssignmentDone",
                column: "levelId");

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignmentDone_teacherId",
                table: "TbAssignmentDone",
                column: "teacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbAssignmentDone_TbLevel_levelId",
                table: "TbAssignmentDone",
                column: "levelId",
                principalTable: "TbLevel",
                principalColumn: "LevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbAssignmentDone_TbTeacher_teacherId",
                table: "TbAssignmentDone",
                column: "teacherId",
                principalTable: "TbTeacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbAssignmentDone_TbLevel_levelId",
                table: "TbAssignmentDone");

            migrationBuilder.DropForeignKey(
                name: "FK_TbAssignmentDone_TbTeacher_teacherId",
                table: "TbAssignmentDone");

            migrationBuilder.DropIndex(
                name: "IX_TbAssignmentDone_levelId",
                table: "TbAssignmentDone");

            migrationBuilder.DropIndex(
                name: "IX_TbAssignmentDone_teacherId",
                table: "TbAssignmentDone");

            migrationBuilder.DropColumn(
                name: "levelId",
                table: "TbAssignmentDone");

            migrationBuilder.DropColumn(
                name: "teacherId",
                table: "TbAssignmentDone");
        }
    }
}
