using AuctionSystem.Api.Domain.Entities;

namespace AuctionSystem.Api.Data;

public static class AuctionSeed
{
    // DateTime.UtcNow cannot be used here because of the way EF seeds data
    private static readonly DateTime _defaultDate = new(2026, 5, 9);

    public static IReadOnlyList<Auction> GetData()
    {
        return
        [
            // User 1 auctions
            // Active
            Create(1, "Vintage Camera", "Classic 35mm film camera in good condition.", 1, 50, 82, ActiveStart(0), ActiveEnd(0), 1),
            Create(2, "Mountain Bike", "Used mountain bike, aluminum frame.", 2, 120, 120, ActiveStart(1), ActiveEnd(1), 1),
            Create(3, "Gaming Laptop", "High‑performance laptop with RTX GPU.", 3, 800, 800, ActiveStart(2), ActiveEnd(2), 1),
            Create(4, "Smartwatch", "Waterproof smartwatch with GPS.", 1, 90, 90, ActiveStart(3), ActiveEnd(3), 1),
            Create(5, "Acoustic Guitar", "Beginner‑friendly acoustic guitar.", 4, 60, 60, ActiveStart(4), ActiveEnd(4), 1),

            // Draft
            Create(6, "Office Chair", "Ergonomic chair with lumbar support.", 5, 40, 40, DraftStart(0), DraftEnd(0), 1),
            Create(7, "Bluetooth Speaker", "Portable speaker with deep bass.", 1, 30, 30, DraftStart(1), DraftEnd(1), 1),
            Create(8, "Cookware Set", "10‑piece stainless steel cookware.", 6, 70, 70, DraftStart(2), DraftEnd(2), 1),

            // Finished
            Create(9, "Drone", "Quadcopter with HD camera.", 1, 150, 150, FinishedStart(0), FinishedEnd(0), 1),
            Create(10, "Leather Wallet", "Handmade genuine leather wallet.", 7, 25, 25, FinishedStart(1), FinishedEnd(1), 1),
            Create(11, "Desk Lamp", "LED lamp with adjustable brightness.", 6, 20, 20, FinishedStart(2), FinishedEnd(2), 1),

            // User 2 auctions
            // Active
            Create(12, "Electric Guitar", "Great for rock and blues.", 4, 150, 210, ActiveStart(0), ActiveEnd(0), 2),
            Create(13, "Coffee Machine", "Automatic espresso machine.", 6, 200, 200, ActiveStart(1), ActiveEnd(1), 2),
            Create(14, "Tablet", "10‑inch tablet for work and play.", 1, 180, 180, ActiveStart(2), ActiveEnd(2), 2),
            Create(15, "Running Shoes", "Lightweight running shoes.", 2, 50, 50, ActiveStart(3), ActiveEnd(3), 2),
            Create(16, "Monitor 27\"", "144Hz gaming monitor.", 3, 220, 220, ActiveStart(4), ActiveEnd(4), 2),

            // Draft
            Create(17, "Keyboard", "Mechanical keyboard with RGB.", 3, 70, 70, DraftStart(0), DraftEnd(0), 2),
            Create(18, "Smartphone", "Unlocked Android phone.", 1, 300, 300, DraftStart(1), DraftEnd(1), 2),
            Create(19, "Camping Tent", "4‑person waterproof tent.", 8, 90, 90, DraftStart(2), DraftEnd(2), 2),

            // Finished
            Create(20, "Sunglasses", "Polarized UV protection.", 7, 35, 35, FinishedStart(0), FinishedEnd(0), 2),
            Create(21, "Backpack", "Durable travel backpack.", 9, 45, 45, FinishedStart(1), FinishedEnd(1), 2),
            Create(22, "Electric Kettle", "Fast‑boil stainless steel kettle.", 6, 25, 25, FinishedStart(2), FinishedEnd(2), 2),

            // User 3 auctions
            // Active
            Create(23, "Road Bike", "Lightweight carbon frame.", 2, 500, 600, ActiveStart(0), ActiveEnd(0), 3),
            Create(24, "4K TV", "55‑inch UHD Smart TV.", 1, 400, 400, ActiveStart(1), ActiveEnd(1), 3),
            Create(25, "Electric Scooter", "Foldable scooter with long battery life.", 15, 350, 350, ActiveStart(2), ActiveEnd(2), 3),
            Create(26, "Air Purifier", "HEPA filter air purifier.", 6, 80, 80, ActiveStart(3), ActiveEnd(3), 3),
            Create(27, "Electric Drill", "Cordless drill with accessories.", 16, 60, 60, ActiveStart(4), ActiveEnd(4), 3),

            // Draft
            Create(28, "Winter Jacket", "Insulated waterproof jacket.", 7, 90, 90, DraftStart(0), DraftEnd(0), 3),
            Create(29, "Wireless Headphones", "Noise‑cancelling over‑ear headphones.", 1, 120, 120, DraftStart(1), DraftEnd(1), 3),
            Create(30, "Gaming Chair", "Ergonomic gaming chair.", 5, 150, 150, DraftStart(2), DraftEnd(2), 3),

            // Finished
            Create(31, "Cookbook Collection", "Set of 5 bestselling cookbooks.", 12, 35, 35, FinishedStart(0), FinishedEnd(0), 3),
            Create(32, "Fitness Tracker", "Tracks steps, sleep, and heart rate.", 1, 45, 45, FinishedStart(1), FinishedEnd(1), 3),
            Create(33, "Desk Organizer", "Wooden organizer for office supplies.", 6, 20, 20, FinishedStart(2), FinishedEnd(2), 3),

            // User 4 auctions
            // Active
            Create(34, "Vinyl Record Player", "Retro turntable with speakers.", 4, 100, 155, ActiveStart(0), ActiveEnd(0), 4),
            Create(35, "Sofa", "Comfortable 3‑seat sofa.", 5, 250, 250, ActiveStart(1), ActiveEnd(1), 4),
            Create(36, "Projector", "1080p home cinema projector.", 1, 180, 180, ActiveStart(2), ActiveEnd(2), 4),
            Create(37, "Ski Set", "Skis, poles, and boots.", 2, 300, 300, ActiveStart(3), ActiveEnd(3), 4),
            Create(38, "Electric Grill", "Indoor smokeless grill.", 6, 70, 70, ActiveStart(4), ActiveEnd(4), 4),

            // Draft
            Create(39, "Luggage Set", "3‑piece travel luggage.", 9, 120, 120, DraftStart(0), DraftEnd(0), 4),
            Create(40, "Electric Toothbrush", "Rechargeable toothbrush with timer.", 10, 40, 40, DraftStart(1), DraftEnd(1), 4),
            Create(41, "Board Game Set", "Collection of 10 classic board games.", 11, 30, 30, DraftStart(2), DraftEnd(2), 4),

            // Finished
            Create(42, "Electric Heater", "Portable ceramic heater.", 6, 35, 35, FinishedStart(0), FinishedEnd(0), 4),
            Create(43, "Car Vacuum", "Compact vacuum for car interiors.", 14, 25, 25, FinishedStart(1), FinishedEnd(1), 4),
            Create(44, "Yoga Mat", "Non‑slip yoga mat.", 2, 20, 20, FinishedStart(2), FinishedEnd(2), 4),

            // User 5 auctions
            // Active
            Create(45, "Laptop Stand", "Adjustable aluminum stand.", 3, 30, 55, ActiveStart(0), ActiveEnd(0), 5),
            Create(46, "Microwave Oven", "700W compact microwave.", 6, 60, 60, ActiveStart(1), ActiveEnd(1), 5),
            Create(47, "Electric Guitar Amp", "20W practice amplifier.", 4, 80, 80, ActiveStart(2), ActiveEnd(2), 5),
            Create(48, "Smart Home Hub", "Controls smart devices.", 1, 55, 55, ActiveStart(3), ActiveEnd(3), 5),
            Create(49, "Air Fryer", "Oil‑less cooking appliance.", 6, 65, 65, ActiveStart(4), ActiveEnd(4), 5),

            // Draft
            Create(50, "Photography Lighting Kit", "Softbox lighting set for studio work.", 13, 85, 85, DraftStart(0), DraftEnd(0), 5),
            Create(51, "Electric Shaver", "Rechargeable shaver with precision blades.", 10, 40, 40, DraftStart(1), DraftEnd(1), 5),
            Create(52, "Portable Hard Drive", "1TB USB 3.0 external drive.", 3, 55, 55, DraftStart(2), DraftEnd(2), 5),

            // Finished
            Create(53, "Car Phone Holder", "Dashboard mount for smartphones.", 14, 15, 15, FinishedStart(0), FinishedEnd(0), 5),
            Create(54, "Electric Blanket", "Heated blanket with adjustable settings.", 6, 45, 45, FinishedStart(1), FinishedEnd(1), 5),
            Create(55, "Wireless Mouse", "Ergonomic mouse with long battery life.", 3, 25, 25, FinishedStart(2), FinishedEnd(2), 5)
        ];
    }

    private static Auction Create
    (
        int id,
        string title,
        string description,
        int categoryId,
        decimal startingPrice,
        decimal currentPrice,
        DateTime startDate,
        DateTime endDate,
        int ownerId
    )
    {
        return new Auction
        {
            Id = id,
            Title = title,
            Description = description,
            CategoryId = categoryId,
            StartingPrice = startingPrice,
            CurrentPrice = currentPrice,
            StartDate = startDate,
            EndDate = endDate,
            OwnerId = ownerId
        };
    }

    private static DateTime DraftStart(int offset)
    {
        return _defaultDate.AddDays(30 + offset);
    }

    private static DateTime DraftEnd(int offset)
    {
        return _defaultDate.AddDays(60 + offset);
    }

    private static DateTime ActiveStart(int offset)
    {
        return _defaultDate.AddDays(-30 + offset);
    }

    private static DateTime ActiveEnd(int offset)
    {
        return _defaultDate.AddDays(30 + offset);
    }

    private static DateTime FinishedStart(int offset)
    {
        return _defaultDate.AddDays(-60 + offset);
    }

    private static DateTime FinishedEnd(int offset)
    {
        return _defaultDate.AddDays(-30 + offset);
    }
}