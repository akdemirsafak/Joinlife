using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.Repository.Migrations
{
    /// <inheritdoc />
    public partial class OrderStatusAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Statu",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statu",
                table: "Orders");
        }
    }
}
