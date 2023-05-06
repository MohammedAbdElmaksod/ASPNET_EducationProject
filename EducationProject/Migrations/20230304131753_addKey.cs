using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationProject.Migrations
{
    /// <inheritdoc />
    public partial class addKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

         


            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TbVideos",
                type: "int",
                nullable: true);


            migrationBuilder.CreateIndex(
                name: "IX_TbVideos_TeacherId",
                table: "TbVideos",
                column: "TeacherId");


            migrationBuilder.AddForeignKey(
                name: "FK_TbVideos_TbTeacher_TeacherId",
                table: "TbVideos",
                column: "TeacherId",
                principalTable: "TbTeacher",
                principalColumn: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbTeacher_TbMatrial",
                table: "TbTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_TbVideos_TbLevel",
                table: "TbVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_TbVideos_TbMatrial",
                table: "TbVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_TbVideos_TbTeacher_TeacherId",
                table: "TbVideos");

            migrationBuilder.DropIndex(
                name: "IX_TbVideos_TeacherId",
                table: "TbVideos");

            migrationBuilder.DropIndex(
                name: "IX_TbTeacher_MatrialId",
                table: "TbTeacher");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TbVideos");

            migrationBuilder.DropColumn(
                name: "MatrialId",
                table: "TbTeacher");

            migrationBuilder.AlterColumn<int>(
                name: "MatrialId",
                table: "TbVideos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LevelId",
                table: "TbVideos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TbMatrial",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbMatrial_TeacherId",
                table: "TbMatrial",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbMatrial_TbTeacher",
                table: "TbMatrial",
                column: "TeacherId",
                principalTable: "TbTeacher",
                principalColumn: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbVideos_TbLevel",
                table: "TbVideos",
                column: "LevelId",
                principalTable: "TbLevel",
                principalColumn: "LevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbVideos_TbMatrial",
                table: "TbVideos",
                column: "MatrialId",
                principalTable: "TbMatrial",
                principalColumn: "MatrialID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
