using AuctionSystem.Api.Domain.Entities;

namespace AuctionSystem.Api.Data;

public static class UserSeed
{
    private const string PasswordHash = "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO";

    public static IReadOnlyList<User> GetData()
    {
        return
        [
            Create(1, "jdoe", "John", "Doe", PasswordHash),
            Create(2, "asmith", "Alice", "Smith", PasswordHash),
            Create(3, "bjackson", "Brian", "Jackson", PasswordHash),
            Create(4, "cwilson", "Chloe", "Wilson", PasswordHash),
            Create(5, "dthomas", "David", "Thomas", PasswordHash),
            Create(6, "eclark", "Emma", "Clark", PasswordHash),
            Create(7, "fmartin", "Frank", "Martin", PasswordHash),
            Create(8, "gwhite", "Grace", "White", PasswordHash),
            Create(9, "hwalker", "Henry", "Walker", PasswordHash),
            Create(10, "ijohnson", "Isabella", "Johnson", PasswordHash),
            Create(11, "jlewis", "James", "Lewis", PasswordHash),
            Create(12, "kroberts", "Karen", "Roberts", PasswordHash),
            Create(13, "lking", "Liam", "King", PasswordHash),
            Create(14, "mgreen", "Mia", "Green", PasswordHash),
            Create(15, "nwright", "Noah", "Wright", PasswordHash),
            Create(16, "oallen", "Olivia", "Allen", PasswordHash),
            Create(17, "pphillips", "Paul", "Phillips", PasswordHash),
            Create(18, "qcampbell", "Quinn", "Campbell", PasswordHash),
            Create(19, "rturner", "Ryan", "Turner", PasswordHash),
            Create(20, "smoore", "Sophia", "Moore", PasswordHash),
            Create(21, "tward", "Thomas", "Ward", PasswordHash)
        ];
    }

    private static User Create(int id, string username, string name, string surname, string passwordHash)
    {
        return new User
        {
            Id = id,
            Username = username,
            Surname = surname,
            Name = name,
            PasswordHash = passwordHash
        };
    }
}