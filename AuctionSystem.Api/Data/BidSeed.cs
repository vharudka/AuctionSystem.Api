using AuctionSystem.Api.Domain.Entities;

namespace AuctionSystem.Api.Data;

public class BidSeed
{
    // DateTime.UtcNow cannot be used here because of the way EF seeds data
    private static readonly DateTime _defaultDate = new(2026, 5, 9);

    public static IReadOnlyList<Bid> GetData()
    {
        return
        [
            // Auction 1
            Create(1, 55, _defaultDate.AddMinutes(-120), 1, 6),
            Create(2, 60, _defaultDate.AddMinutes(-90), 1, 7),
            Create(3, 68, _defaultDate.AddMinutes(-60), 1, 8),
            Create(4, 75, _defaultDate.AddMinutes(-30), 1, 9),
            Create(5, 82, _defaultDate.AddMinutes(-10), 1, 10),

            // Auction 12
            Create(6, 160, _defaultDate.AddMinutes(-140), 12, 6),
            Create(7, 170, _defaultDate.AddMinutes(-100), 12, 7),
            Create(8, 185, _defaultDate.AddMinutes(-70), 12, 8),
            Create(9, 195, _defaultDate.AddMinutes(-40), 12, 9),
            Create(10, 210, _defaultDate.AddMinutes(-15), 12, 10),

            // Auction 23
            Create(11, 520, _defaultDate.AddMinutes(-180), 23, 6),
            Create(12, 540, _defaultDate.AddMinutes(-120), 23, 7),
            Create(13, 560, _defaultDate.AddMinutes(-90), 23, 8),
            Create(14, 580, _defaultDate.AddMinutes(-45), 23, 9),
            Create(15, 600, _defaultDate.AddMinutes(-20), 23, 10),

            // Auction 34
            Create(16, 110, _defaultDate.AddMinutes(-160), 34, 6),
            Create(17, 120, _defaultDate.AddMinutes(-110), 34, 7),
            Create(18, 135, _defaultDate.AddMinutes(-80), 34, 8),
            Create(19, 145, _defaultDate.AddMinutes(-50), 34, 9),
            Create(20, 155, _defaultDate.AddMinutes(-25), 34, 10),

            // Auction 45
            Create(21, 35, _defaultDate.AddMinutes(-130), 45, 6),
            Create(22, 40, _defaultDate.AddMinutes(-95), 45, 7),
            Create(23, 45, _defaultDate.AddMinutes(-70), 45, 8),
            Create(24, 50, _defaultDate.AddMinutes(-35), 45, 9),
            Create(25, 55, _defaultDate.AddMinutes(-10), 45, 10)
        ];
    }

    private static Bid Create(int id, decimal amount, DateTime placedAt, int auctionId, int userId)
    {
        return new Bid
        {
            Id = id,
            Amount = amount,
            PlacedAt = placedAt,
            AuctionId = auctionId,
            UserId = userId
        };
    }
}