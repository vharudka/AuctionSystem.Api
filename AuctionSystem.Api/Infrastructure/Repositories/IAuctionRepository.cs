using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Dtos.Auctions;

namespace AuctionSystem.Api.Infrastructure.Repositories;

public interface IAuctionRepository
{
    Task<Auction?> GetByIdAsync(int id);
    Task<PagedResult<Auction>> GetAllAsync(AuctionQueryParameters query);
    Task AddAsync(Auction auction);
    Task UpdateAsync(Auction auction);
    Task DeleteAsync(Auction auction);
    Task SaveChangesAsync();
}