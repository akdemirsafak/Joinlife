using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event.API.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPriceAndTicketAmounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SellableTicketAmount",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SelledTicketAmount",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Events",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SellableTicketAmount",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelledTicketAmount",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
