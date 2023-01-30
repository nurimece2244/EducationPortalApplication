using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EducationCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "EducationCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "EducationCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
