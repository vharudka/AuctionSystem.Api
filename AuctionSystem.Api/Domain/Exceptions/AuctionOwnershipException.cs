namespace AuctionSystem.Api.Domain.Exceptions;

public class AuctionOwnershipException : Exception
{
    public int AuctionId { get; }
    public int UserId { get; }

    public AuctionOwnershipException(int auctionId, int userId)
        : base($"User {userId} is not allowed to modify auction {auctionId}.")
    {
        AuctionId = auctionId;
        UserId = userId;
    }
}