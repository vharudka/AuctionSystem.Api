namespace AuctionSystem.Api.Domain.Exceptions;

public class AuctionFinishedException : Exception
{
    public AuctionFinishedException()
        : base("You cannot bid on an auction that has already finished.") { }
}