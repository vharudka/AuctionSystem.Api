namespace AuctionSystem.Api.Domain.Exceptions;

public class AuctionNotDraftException : Exception
{
    public AuctionNotDraftException()
        : base("You can only update/delete auctions that are in draft status.") { }
}