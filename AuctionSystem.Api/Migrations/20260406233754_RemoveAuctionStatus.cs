using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuctionStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Auctions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
