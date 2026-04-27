using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Domain.Exceptions;
using AuctionSystem.Api.Dtos.Bids;
using AuctionSystem.Api.Infrastructure.Repositories;
using AuctionSystem.Api.Services;
using Moq;

namespace AuctionSystem.Api.Tests.Services;

[TestClass]
public class BidServiceTests
{
    private Mock<IBidRepository> _bidRepo = null!;
    private Mock<IAuctionRepository> _auctionRepo = null!;
    private Mock<IUserRepository> _userRepo = null!;
    private BidService _service = null!;

    [TestInitialize]
    public void Setup()
    {
        _bidRepo = new Mock<IBidRepository>();
        _auctionRepo = new Mock<IAuctionRepository>();
        _userRepo = new Mock<IUserRepository>();
        _service = new BidService(_bidRepo.Object, _auctionRepo.Object, _userRepo.Object);
    }

    [TestMethod]
    public async Task GetAllAsync_AuctionNotFound_ThrowsException()
    {
        var query = new BidQueryParameters(null,
                                           true,
                                           1,
                                           10);

        _auctionRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync((Auction?)null);

        await Assert.ThrowsExactlyAsync<AuctionNotFoundException>(async () =>
            await _service.GetAllAsync(1, query));
    }

    [TestMethod]
    public async Task GetAllAsync_ValidRequest_ReturnsPagedResult()
    {
        var auction = new Auction { Id = 1 };
        _auctionRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(auction);

        var bids = new List<Bid>
        {
            new() { Id = 1, AuctionId = 1, UserId = 5, Amount = 100 },
            new() { Id = 2, AuctionId = 1, UserId = 6, Amount = 120 }
        };

        var paged = new PagedResult<Bid>(bids, 1, 10, 2);

        var query = new BidQueryParameters(null,
                                           true,
                                           1,
                                           10);

        _bidRepo.Setup(r => r.GetAllByAuctionIdAsync(1, It.IsAny<BidQueryParameters>()))
                .ReturnsAsync(paged);

        var result = await _service.GetAllAsync(1, query);

        Assert.AreEqual(2, result.TotalCount);
        Assert.AreEqual(2, result.Items.Count());

        _bidRepo.Verify(r => r.GetAllByAuctionIdAsync(1, It.IsAny<BidQueryParameters>()), Times.Once);
    }

    [TestMethod]
    public async Task CreateAsync_AuctionNotFound_ThrowsException()
    {
        _auctionRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync((Auction?)null);

        await Assert.ThrowsExactlyAsync<AuctionNotFoundException>(async () =>
            await _service.CreateAsync(1, 5, new CreateBidRequest(100)));
    }

    [TestMethod]
    public async Task CreateAsync_UserNotFound_ThrowsException()
    {
        _auctionRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(new Auction());

        _userRepo.Setup(r => r.GetByIdAsync(5))
                 .ReturnsAsync((User?)null);

        await Assert.ThrowsExactlyAsync<UserNotFoundException>(async () =>
            await _service.CreateAsync(1, 5, new CreateBidRequest(100)));
    }

    [TestMethod]
    public async Task CreateAsync_AuctionDraft_ThrowsAuctionNotActive()
    {
        var auction = new Auction
        {
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(2)
        };

        _auctionRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(auction);
        _userRepo.Setup(r => r.GetByIdAsync(5)).ReturnsAsync(new User());

        await Assert.ThrowsExactlyAsync<AuctionNotActiveException>(async () =>
            await _service.CreateAsync(1, 5, new CreateBidRequest(100)));
    }

    [TestMethod]
    public async Task CreateAsync_AuctionFinished_ThrowsAuctionExpired()
    {
        var auction = new Auction
        {
            StartDate = DateTime.UtcNow.AddDays(-5),
            EndDate = DateTime.UtcNow.AddDays(-1)
        };

        _auctionRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(auction);
        _userRepo.Setup(r => r.GetByIdAsync(5)).ReturnsAsync(new User());

        await Assert.ThrowsExactlyAsync<AuctionFinishedException>(async () =>
            await _service.CreateAsync(1, 5, new CreateBidRequest(100)));
    }

    [TestMethod]
    public async Task CreateAsync_BidTooLow_ThrowsException()
    {
        var auction = new Auction
        {
            CurrentPrice = 100,
            StartDate = DateTime.UtcNow.AddDays(-1),
            EndDate = DateTime.UtcNow.AddDays(1)
        };

        _auctionRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(auction);
        _userRepo.Setup(r => r.GetByIdAsync(5)).ReturnsAsync(new User());

        await Assert.ThrowsExactlyAsync<BidTooLowException>(async () =>
            await _service.CreateAsync(1, 5, new CreateBidRequest(100)));
    }

    [TestMethod]
    public async Task CreateAsync_ValidBid_CreatesBidAndUpdatesAuction()
    {
        var auction = new Auction
        {
            Id = 1,
            CurrentPrice = 100,
            StartDate = DateTime.UtcNow.AddDays(-1),
            EndDate = DateTime.UtcNow.AddDays(1)
        };

        _auctionRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(auction);
        _userRepo.Setup(r => r.GetByIdAsync(5)).ReturnsAsync(new User());

        _bidRepo.Setup(r => r.AddAsync(It.IsAny<Bid>()))
                .Returns(Task.CompletedTask);

        _auctionRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);
        _bidRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

        var response = await _service.CreateAsync(1, 5, new CreateBidRequest(150));

        Assert.AreEqual(150, auction.CurrentPrice);
        Assert.IsNotNull(response);
        Assert.AreEqual(150, response.Amount);
        Assert.AreEqual(5, response.UserId);
        Assert.AreEqual(1, response.AuctionId);

        _auctionRepo.Verify(r => r.GetByIdAsync(1), Times.Once);
        _auctionRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        _userRepo.Verify(r => r.GetByIdAsync(5), Times.Once);
        _bidRepo.Verify(r => r.AddAsync(It.IsAny<Bid>()), Times.Once);
        _bidRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}