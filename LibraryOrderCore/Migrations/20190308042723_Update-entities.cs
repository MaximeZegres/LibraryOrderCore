using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryOrderCore.Migrations
{
    public partial class Updateentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "OrderItemId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "Items",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");
        }
    }
}
