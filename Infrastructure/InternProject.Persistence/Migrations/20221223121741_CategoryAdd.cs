using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategoryAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationCategoryId",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EducationCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EducationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationCategory", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Education_EducationCategoryId",
                table: "Education",
                column: "EducationCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_EducationCategory_EducationCategoryId",
                table: "Education",
                column: "EducationCategoryId",
                principalTable: "EducationCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_EducationCategory_EducationCategoryId",
                table: "Education");

            migrationBuilder.DropTable(
                name: "EducationCategory");

            migrationBuilder.DropIndex(
                name: "IX_Education_EducationCategoryId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "EducationCategoryId",
                table: "Education");
        }
    }
}
