namespace AuctionSystem.Api.Dtos.Users;

public record UserResponse(
    int Id,
    string Username,
    string Name,
    string Surname
);