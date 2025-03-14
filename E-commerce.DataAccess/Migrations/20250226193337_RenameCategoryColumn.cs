using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameCategoryColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DesplayOrder",
                table: "Categories",
                newName: "DisplayOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Categories",
                newName: "DesplayOrder");
        }
    }
}
