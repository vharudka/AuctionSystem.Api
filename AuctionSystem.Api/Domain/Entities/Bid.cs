namespace AuctionSystem.Api.Domain.Entities;

public class Bid : Base
{
    public decimal Amount { get; set; }
    public DateTime PlacedAt { get; set; }

    public int AuctionId { get; set; }
    public Auction? Auction { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}