using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPizzeria.Migrations
{
    public partial class addedContents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contents",
                table: "PizzaOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contents",
                table: "PizzaOrders");
        }
    }
}
