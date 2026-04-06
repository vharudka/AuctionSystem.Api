namespace AuctionSystem.Api.Domain.Exceptions;

public class AuctionNotActiveException : Exception
{
    public AuctionNotActiveException()
        : base("You can only bid on active auctions.") { }
}