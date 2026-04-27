namespace AuctionSystem.Api.Domain.Entities;

#nullable disable
public class Category : Base
{
    public string Name { get; set; }

    public ICollection<Auction> Auctions { get; set; }
}