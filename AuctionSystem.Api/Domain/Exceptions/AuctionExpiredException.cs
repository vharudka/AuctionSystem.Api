namespace AuctionSystem.Api.Domain.Exceptions;

public class AuctionExpiredException : Exception
{
    public AuctionExpiredException()
        : base("You cannot bid on an auction that has already finished.") { }
}