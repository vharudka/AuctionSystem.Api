using AuctionSystem.Api.Domain.Enums;

namespace AuctionSystem.Api.Dtos.Auctions;

public record UpdateAuctionRequest(
    string Title,
    string Description,
    string Category,
    decimal StartingPrice,
    DateTime StartDate,
    DateTime EndDate,
    AuctionStatus Status
);