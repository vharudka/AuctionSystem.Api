namespace AuctionSystem.Api.Dtos;

public record UserResponse(
    int Id,
    string Username,
    string Name,
    string Surname
);