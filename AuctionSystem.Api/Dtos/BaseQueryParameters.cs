namespace AuctionSystem.Api.Dtos;

public abstract record BaseQueryParameters(
    string? Search,
    string? SortBy,
    bool Desc,
    int Page,
    int PageSize
);