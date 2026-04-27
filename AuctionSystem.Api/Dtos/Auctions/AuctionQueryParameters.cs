using AuctionSystem.Api.Domain.Enums;

namespace AuctionSystem.Api.Dtos.Auctions;

public record AuctionQueryParameters(
    int? CategoryId,
    AuctionStatus? Status,
    string? Search,
    string? SortBy,
    bool Desc,
    int Page,
    int PageSize
) : BaseQueryParameters(Search, SortBy, Desc, Page, PageSize);