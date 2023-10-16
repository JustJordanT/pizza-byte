using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pizza_byte.api.Migrations
{
    /// <inheritdoc />
    public partial class initialv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pizzas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Pizzas",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
