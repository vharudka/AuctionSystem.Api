namespace AuctionSystem.Api.Dtos;

#nullable disable
public class CreateAuctionDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal StartingPrice { get; set; }
    public DateTime EndDate { get; set; }
    public int OwnerId { get; set; }
}