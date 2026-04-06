namespace AuctionSystem.Api.Dtos;

public class CreateBidDto
{
    public int AuctionId { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
}