namespace AuctionSystem.Api.Dtos.Auctions;

public record UpdateAuctionRequest(
    string Title,
    string Description,
    int CategoryId,
    decimal StartingPrice,
    DateTime StartDate,
    DateTime EndDate
);