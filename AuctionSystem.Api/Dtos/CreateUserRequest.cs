namespace AuctionSystem.Api.Dtos;

public record CreateUserRequest(
    string Username,
    string Name,
    string Surname
);