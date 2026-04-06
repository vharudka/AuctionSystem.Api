using AuctionSystem.Api.Infrastructure.Repositories;

namespace AuctionSystem.Api.Infrastructure.BackgroundServices;

public class AuctionStatusUpdater : BackgroundService
{
    private readonly IAuctionRepository _repository;

    public AuctionStatusUpdater(IAuctionRepository repository)
    {
        _repository = repository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _repository.UpdateStatusesAsync();
            await _repository.SaveChangesAsync();
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}