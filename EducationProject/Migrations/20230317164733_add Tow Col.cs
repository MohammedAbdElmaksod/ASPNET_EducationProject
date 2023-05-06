using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationProject.Migrations
{
    /// <inheritdoc />
    public partial class addTowCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Chapter",
                table: "TbVideos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lesson",
                table: "TbVideos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chapter",
                table: "TbVideos");

            migrationBuilder.DropColumn(
                name: "Lesson",
                table: "TbVideos");
        }
    }
}
