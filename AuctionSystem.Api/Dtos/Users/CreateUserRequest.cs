namespace AuctionSystem.Api.Dtos.Users;

public record CreateUserRequest(
    string Username,
    string Name,
    string Surname
);