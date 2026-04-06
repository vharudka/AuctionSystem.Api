namespace AuctionSystem.Api.Dtos;

public class BidDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PlacedAt { get; set; }
    public int UserId { get; set; }
}