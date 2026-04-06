namespace AuctionSystem.Api.Dtos;

public record UserQueryParameters(
    string? Search,
    string? SortBy,
    bool Desc,
    int Page = 1,
    int PageSize = 10
);