using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class KullaniciTakibi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Favorite",
                table: "AssignedEducation",
                newName: "FavoriteEducation");

            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "AssignedEducation",
                newName: "CompletedEducation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavoriteEducation",
                table: "AssignedEducation",
                newName: "Favorite");

            migrationBuilder.RenameColumn(
                name: "CompletedEducation",
                table: "AssignedEducation",
                newName: "Completed");
        }
    }
}
