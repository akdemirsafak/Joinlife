using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Location.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ImageUrlColumnsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Venue",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "City",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "City");
        }
    }
}
