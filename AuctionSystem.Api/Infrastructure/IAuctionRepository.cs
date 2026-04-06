using AuctionSystem.Api.Domain.Entities;

namespace AuctionSystem.Api.Infrastructure;

public interface IAuctionRepository
{
    Task<Auction?> GetByIdAsync(int id);
    Task<IEnumerable<Auction>> GetAllAsync();
    Task AddAsync(Auction auction);
    Task UpdateAsync(Auction auction);
    Task DeleteAsync(Auction auction);
    Task SaveChangesAsync();
}