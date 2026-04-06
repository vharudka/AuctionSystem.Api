using AuctionSystem.Api.Domain.Enums;

namespace AuctionSystem.Api.Dtos.Auctions;

public record AuctionQueryParameters(
    string? Category,
    AuctionStatus? Status,
    string? Search,
    string? SortBy,
    bool Desc,
    int Page,
    int PageSize
) : BaseQueryParameters(Search, SortBy, Desc, Page, PageSize);