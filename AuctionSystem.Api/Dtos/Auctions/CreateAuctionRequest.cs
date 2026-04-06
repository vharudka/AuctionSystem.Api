namespace AuctionSystem.Api.Dtos.Auctions;

public record CreateAuctionRequest(
    string Title,
    string Description,
    decimal StartingPrice,
    DateTime StartDate,
    DateTime EndDate,
    string Category,
    int OwnerId
);