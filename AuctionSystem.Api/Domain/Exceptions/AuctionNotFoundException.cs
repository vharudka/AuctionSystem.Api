namespace AuctionSystem.Api.Domain.Exceptions;

public class AuctionNotFoundException : Exception
{
    public AuctionNotFoundException(int id)
        : base($"Auction with id {id} was not found.") { }
}