using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationProject.Migrations
{
    /// <inheritdoc />
    public partial class addattr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "imgUrl",
                table: "TbAssignmentDone",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "chapter",
                table: "TbAssignmentDone",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lesson",
                table: "TbAssignmentDone",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "chapter",
                table: "TbAssignmentDone");

            migrationBuilder.DropColumn(
                name: "lesson",
                table: "TbAssignmentDone");

            migrationBuilder.AlterColumn<string>(
                name: "imgUrl",
                table: "TbAssignmentDone",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
