namespace AuctionSystem.Api.Dtos.Bids;

public record BidQueryParameters(
    string? SortBy,
    bool Desc,
    int Page,
    int PageSize
) : BaseQueryParameters(null, SortBy, Desc, Page, PageSize);