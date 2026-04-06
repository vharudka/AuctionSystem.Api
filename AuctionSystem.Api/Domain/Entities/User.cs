namespace AuctionSystem.Api.Domain.Entities;

#nullable disable
public class User : Base
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public ICollection<Auction> Auctions { get; set; }
    public ICollection<Bid> Bids { get; set; }
}