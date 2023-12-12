using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Pronia.Migrations
{
    /// <inheritdoc />
    public partial class uptodatenewest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "products");
        }
    }
}
