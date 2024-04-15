using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedEventInTicketEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventyId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventyId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EventyId",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets");

            migrationBuilder.AddColumn<Guid>(
                name: "EventyId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventyId",
                table: "Tickets",
                column: "EventyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventyId",
                table: "Tickets",
                column: "EventyId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
