namespace AuctionSystem.Api.Data;

public interface IEntitySeed<T>
{
    IReadOnlyList<T> GetSeedData();
}