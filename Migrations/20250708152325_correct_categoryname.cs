using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerceWepApi.Migrations
{
    /// <inheritdoc />
    public partial class correct_categoryname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categrories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categrories",
                table: "Categrories");

            migrationBuilder.RenameTable(
                name: "Categrories",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categrories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categrories",
                table: "Categrories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categrories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categrories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
