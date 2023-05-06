using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationProject.Migrations
{
    /// <inheritdoc />
    public partial class addteacherassignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TbAssignment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbAssignment_TeacherId",
                table: "TbAssignment",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbAssignment_TbTeacher_TeacherId",
                table: "TbAssignment",
                column: "TeacherId",
                principalTable: "TbTeacher",
                principalColumn: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbAssignment_TbTeacher_TeacherId",
                table: "TbAssignment");

            migrationBuilder.DropIndex(
                name: "IX_TbAssignment_TeacherId",
                table: "TbAssignment");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TbAssignment");
        }
    }
}
