using AuctionSystem.Api.Domain.Enums;

namespace AuctionSystem.Api.Domain.Entities;

#nullable disable
public class Auction : Base
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal StartingPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public AuctionStatus Status { get; set; } = AuctionStatus.Draft;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int OwnerId { get; set; }
    public User? Owner { get; set; }

    public ICollection<Bid> Bids { get; set; }
}