namespace AuctionSystem.Api.Dtos.Users;

public record UserQueryParameters(
    string? Search,
    string? SortBy,
    bool Desc,
    int Page,
    int PageSize
) : BaseQueryParameters(Search, SortBy, Desc, Page, PageSize);