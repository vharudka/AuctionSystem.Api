namespace AuctionSystem.Api.Domain.Entities;

#nullable disable
public class User : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
}