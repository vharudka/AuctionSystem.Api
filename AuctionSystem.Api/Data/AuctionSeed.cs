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
            Create(1, "Vintage Camera", "Classic 35mm film camera in good condition.", "Electronics", 50, 82, ActiveStart(0), ActiveEnd(0), 1),
            Create(2, "Mountain Bike", "Used mountain bike, aluminum frame.", "Sports", 120, 120, ActiveStart(1), ActiveEnd(1), 1),
            Create(3, "Gaming Laptop", "High‑performance laptop with RTX GPU.", "Computers", 800, 800, ActiveStart(2), ActiveEnd(2), 1),
            Create(4, "Smartwatch", "Waterproof smartwatch with GPS.", "Electronics", 90, 90, ActiveStart(3), ActiveEnd(3), 1),
            Create(5, "Acoustic Guitar", "Beginner‑friendly acoustic guitar.", "Music", 60, 60, ActiveStart(4), ActiveEnd(4), 1),

            // Draft
            Create(6, "Office Chair", "Ergonomic chair with lumbar support.", "Furniture", 40, 40, DraftStart(0), DraftEnd(0), 1),
            Create(7, "Bluetooth Speaker", "Portable speaker with deep bass.", "Electronics", 30, 30, DraftStart(1), DraftEnd(1), 1),
            Create(8, "Cookware Set", "10‑piece stainless steel cookware.", "Home", 70, 70, DraftStart(2), DraftEnd(2), 1),

            // Expired
            Create(9, "Drone", "Quadcopter with HD camera.", "Electronics", 150, 150, ExpiredStart(0), ExpiredEnd(0), 1),
            Create(10, "Leather Wallet", "Handmade genuine leather wallet.", "Fashion", 25, 25, ExpiredStart(1), ExpiredEnd(1), 1),
            Create(11, "Desk Lamp", "LED lamp with adjustable brightness.", "Home", 20, 20, ExpiredStart(2), ExpiredEnd(2), 1),

            // User 2 auctions
            // Active
            Create(12, "Electric Guitar", "Great for rock and blues.", "Music", 150, 210, ActiveStart(0), ActiveEnd(0), 2),
            Create(13, "Coffee Machine", "Automatic espresso machine.", "Home", 200, 200, ActiveStart(1), ActiveEnd(1), 2),
            Create(14, "Tablet", "10‑inch tablet for work and play.", "Electronics", 180, 180, ActiveStart(2), ActiveEnd(2), 2),
            Create(15, "Running Shoes", "Lightweight running shoes.", "Sports", 50, 50, ActiveStart(3), ActiveEnd(3), 2),
            Create(16, "Monitor 27\"", "144Hz gaming monitor.", "Computers", 220, 220, ActiveStart(4), ActiveEnd(4), 2),

            // Draft
            Create(17, "Keyboard", "Mechanical keyboard with RGB.", "Computers", 70, 70, DraftStart(0), DraftEnd(0), 2),
            Create(18, "Smartphone", "Unlocked Android phone.", "Electronics", 300, 300, DraftStart(1), DraftEnd(1), 2),
            Create(19, "Camping Tent", "4‑person waterproof tent.", "Outdoors", 90, 90, DraftStart(2), DraftEnd(2), 2),

            // Expired
            Create(20, "Sunglasses", "Polarized UV protection.", "Fashion", 35, 35, ExpiredStart(0), ExpiredEnd(0), 2),
            Create(21, "Backpack", "Durable travel backpack.", "Travel", 45, 45, ExpiredStart(1), ExpiredEnd(1), 2),
            Create(22, "Electric Kettle", "Fast‑boil stainless steel kettle.", "Home", 25, 25, ExpiredStart(2), ExpiredEnd(2), 2),

            // User 3 auctions
            // Active
            Create(23, "Road Bike", "Lightweight carbon frame.", "Sports", 500, 600, ActiveStart(0), ActiveEnd(0), 3),
            Create(24, "4K TV", "55‑inch UHD Smart TV.", "Electronics", 400, 400, ActiveStart(1), ActiveEnd(1), 3),
            Create(25, "Electric Scooter", "Foldable scooter with long battery life.", "Transport", 350, 350, ActiveStart(2), ActiveEnd(2), 3),
            Create(26, "Air Purifier", "HEPA filter air purifier.", "Home", 80, 80, ActiveStart(3), ActiveEnd(3), 3),
            Create(27, "Electric Drill", "Cordless drill with accessories.", "Tools", 60, 60, ActiveStart(4), ActiveEnd(4), 3),

            // Draft
            Create(28, "Winter Jacket", "Insulated waterproof jacket.", "Fashion", 90, 90, DraftStart(0), DraftEnd(0), 3),
            Create(29, "Wireless Headphones", "Noise‑cancelling over‑ear headphones.", "Electronics", 120, 120, DraftStart(1), DraftEnd(1), 3),
            Create(30, "Gaming Chair", "Ergonomic gaming chair.", "Furniture", 150, 150, DraftStart(2), DraftEnd(2), 3),

            // Expired
            Create(31, "Cookbook Collection", "Set of 5 bestselling cookbooks.", "Books", 35, 35, ExpiredStart(0), ExpiredEnd(0), 3),
            Create(32, "Fitness Tracker", "Tracks steps, sleep, and heart rate.", "Electronics", 45, 45, ExpiredStart(1), ExpiredEnd(1), 3),
            Create(33, "Desk Organizer", "Wooden organizer for office supplies.", "Home", 20, 20, ExpiredStart(2), ExpiredEnd(2), 3),

            // User 4 auctions,
            // Active
            Create(34, "Vinyl Record Player", "Retro turntable with speakers.", "Music", 100, 155, ActiveStart(0), ActiveEnd(0), 4),
            Create(35, "Sofa", "Comfortable 3‑seat sofa.", "Furniture", 250, 250, ActiveStart(1), ActiveEnd(1), 4),
            Create(36, "Projector", "1080p home cinema projector.", "Electronics", 180, 180, ActiveStart(2), ActiveEnd(2), 4),
            Create(37, "Ski Set", "Skis, poles, and boots.", "Sports", 300, 300, ActiveStart(3), ActiveEnd(3), 4),
            Create(38, "Electric Grill", "Indoor smokeless grill.", "Home", 70, 70, ActiveStart(4), ActiveEnd(4), 4),

            // Draft
            Create(39, "Luggage Set", "3‑piece travel luggage.", "Travel", 120, 120, DraftStart(0), DraftEnd(0), 4),
            Create(40, "Electric Toothbrush", "Rechargeable toothbrush with timer.", "Health", 40, 40, DraftStart(1), DraftEnd(1), 4),
            Create(41, "Board Game Set", "Collection of 10 classic board games.", "Games", 30, 30, DraftStart(2), DraftEnd(2), 4),

            // Expired
            Create(42, "Electric Heater", "Portable ceramic heater.", "Home", 35, 35, ExpiredStart(0), ExpiredEnd(0), 4),
            Create(43, "Car Vacuum", "Compact vacuum for car interiors.", "Automotive", 25, 25, ExpiredStart(1), ExpiredEnd(1), 4),
            Create(44, "Yoga Mat", "Non‑slip yoga mat.", "Sports", 20, 20, ExpiredStart(2), ExpiredEnd(2), 4),

            // User 5 auctions
            // Active
            Create(45, "Laptop Stand", "Adjustable aluminum stand.", "Computers", 30, 55, ActiveStart(0), ActiveEnd(0), 5),
            Create(46, "Microwave Oven", "700W compact microwave.", "Home", 60, 60, ActiveStart(1), ActiveEnd(1), 5),
            Create(47, "Electric Guitar Amp", "20W practice amplifier.", "Music", 80, 80, ActiveStart(2), ActiveEnd(2), 5),
            Create(48, "Smart Home Hub", "Controls smart devices.", "Electronics", 55, 55, ActiveStart(3), ActiveEnd(3), 5),
            Create(49, "Air Fryer", "Oil‑less cooking appliance.", "Home", 65, 65, ActiveStart(4), ActiveEnd(4), 5),

            // Draft
            Create(50, "Photography Lighting Kit", "Softbox lighting set for studio work.", "Photography", 85, 85, DraftStart(0), DraftEnd(0), 5),
            Create(51, "Electric Shaver", "Rechargeable shaver with precision blades.", "Health", 40, 40, DraftStart(1), DraftEnd(1), 5),
            Create(52, "Portable Hard Drive", "1TB USB 3.0 external drive.", "Computers", 55, 55, DraftStart(2), DraftEnd(2), 5),

            // Expired
            Create(53, "Car Phone Holder", "Dashboard mount for smartphones.", "Automotive", 15, 15, ExpiredStart(0), ExpiredEnd(0), 5),
            Create(54, "Electric Blanket", "Heated blanket with adjustable settings.", "Home", 45, 45, ExpiredStart(1), ExpiredEnd(1), 5),
            Create(55, "Wireless Mouse", "Ergonomic mouse with long battery life.", "Computers", 25, 25, ExpiredStart(2), ExpiredEnd(2), 5)
        ];
    }

    private static Auction Create(int id, string title, string description, string category, decimal startingPrice, decimal currentPrice, DateTime startDate, DateTime endDate, int ownerId)
    {
        return new Auction
        {
            Id = id,
            Title = title,
            Description = description,
            Category = category,
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

    private static DateTime ExpiredStart(int offset)
    {
        return _defaultDate.AddDays(-60 + offset);
    }

    private static DateTime ExpiredEnd(int offset)
    {
        return _defaultDate.AddDays(-30 + offset);
    }
}