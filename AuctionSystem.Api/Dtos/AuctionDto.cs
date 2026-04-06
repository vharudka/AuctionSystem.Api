namespace AuctionSystem.Api.Dtos;

#nullable disable
public class AuctionDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal StartingPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public DateTime EndDate { get; set; }
    public int OwnerId { get; set; }
}