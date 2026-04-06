using AuctionSystem.Api.Domain.Enums;

namespace AuctionSystem.Api.Helpers;

public static class AuctionStatusCalculator
{
    public static AuctionStatus GetStatus(DateTime startDate, DateTime endDate)
    {
        var now = DateTime.UtcNow;

        if (startDate > now)
        {
            return AuctionStatus.Draft;
        }

        if (endDate <= now)
        {
            return AuctionStatus.Finished;
        }

        return AuctionStatus.Active;
    }
}