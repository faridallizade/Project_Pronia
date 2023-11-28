using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Pronia.Migrations
{
    /// <inheritdoc />
    public partial class editedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoriesId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productImages_ImagesId",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "ImagesId",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriesId",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoriesId",
                table: "products",
                column: "CategoriesId",
                principalTable: "categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productImages_ImagesId",
                table: "products",
                column: "ImagesId",
                principalTable: "productImages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoriesId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productImages_ImagesId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "ImagesId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriesId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoriesId",
                table: "products",
                column: "CategoriesId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productImages_ImagesId",
                table: "products",
                column: "ImagesId",
                principalTable: "productImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
