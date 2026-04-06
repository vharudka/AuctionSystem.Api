namespace AuctionSystem.Api.Domain.Exceptions;

public class BidTooLowException : Exception
{
    public BidTooLowException(decimal currentPrice)
        : base($"Bid amount must be higher than the current price ({currentPrice}).") { }
}