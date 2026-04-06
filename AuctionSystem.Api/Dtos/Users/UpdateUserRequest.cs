namespace AuctionSystem.Api.Dtos.Users;

public record UpdateUserRequest(
    string Name,
    string Surname
);