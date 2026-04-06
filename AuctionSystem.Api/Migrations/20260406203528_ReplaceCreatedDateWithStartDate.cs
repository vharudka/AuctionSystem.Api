using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceCreatedDateWithStartDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Auctions",
                newName: "StartDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Auctions",
                newName: "CreatedAt");
        }
    }
}
