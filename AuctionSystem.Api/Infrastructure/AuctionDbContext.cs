using AuctionSystem.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionSystem.Api.Infrastructure;

public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions<AuctionDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Auction> Auctions => Set<Auction>();
    public DbSet<Bid> Bids => Set<Bid>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}