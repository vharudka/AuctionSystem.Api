namespace AuctionSystem.Api.Dtos.Bids;

public record BidResponse(
    int Id,
    int AuctionId,
    int UserId,
    decimal Amount,
    DateTime PlacedAt
);