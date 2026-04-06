namespace AuctionSystem.Api.Dtos.Bids;

public record CreateBidRequest(
    int UserId,
    decimal Amount
);