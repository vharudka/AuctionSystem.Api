namespace AuctionSystem.Api.Domain.Entities;

#nullable disable
public class User : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }

    public ICollection<Auction> Auctions { get; set; }
    public ICollection<Bid> Bids { get; set; }
}