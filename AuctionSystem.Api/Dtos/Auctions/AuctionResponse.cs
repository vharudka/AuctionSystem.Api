using AuctionSystem.Api.Domain.Enums;

namespace AuctionSystem.Api.Dtos.Auctions;

public record AuctionResponse(
    int Id,
    string Title,
    string Description,
    string Category,
    decimal StartingPrice,
    decimal CurrentPrice,
    DateTime StartDate,
    DateTime EndDate,
    string Status,
    int OwnerId
);