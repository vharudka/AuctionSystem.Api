namespace AuctionSystem.Api.Domain.Entities;

#nullable disable
public class Auction : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal StartingPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public DateTime EndDate { get; set; }

    public int OwnerId { get; set; }
    public User? Owner { get; set; }
}