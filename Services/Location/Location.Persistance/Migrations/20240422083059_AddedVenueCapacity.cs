using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Location.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddedVenueCapacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Venue",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Venue");
        }
    }
}
