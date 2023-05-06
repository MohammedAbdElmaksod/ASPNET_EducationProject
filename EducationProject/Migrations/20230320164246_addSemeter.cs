using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationProject.Migrations
{
    /// <inheritdoc />
    public partial class addSemeter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<int>(
                name: "semester",
                table: "TbVideos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "semester",
                table: "TbVideos");

           
        }
    }
}
