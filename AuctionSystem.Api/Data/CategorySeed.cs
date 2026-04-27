using AuctionSystem.Api.Domain.Entities;

namespace AuctionSystem.Api.Data;

public static class CategorySeed
{
    public static IReadOnlyList<Category> GetData()
    {
        return
        [
            Create(1, "Electronics"),
            Create(2, "Sports"),
            Create(3, "Computers"),
            Create(4, "Music"),
            Create(5, "Furniture"),
            Create(6, "Home"),
            Create(7, "Fashion"),
            Create(8, "Outdoors"),
            Create(9, "Travel"),
            Create(10, "Health"),
            Create(11, "Games"),
            Create(12, "Books"),
            Create(13, "Photography"),
            Create(14, "Automotive"),
            Create(15, "Transport"),
            Create(16, "Tools")
        ];
    }

    private static Category Create(int id, string name)
    {
        return new Category
        {
            Id = id,
            Name = name
        };
    }
}