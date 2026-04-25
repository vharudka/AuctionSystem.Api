using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Domain.Exceptions;
using AuctionSystem.Api.Dtos.Auctions;
using AuctionSystem.Api.Infrastructure.Repositories;
using AuctionSystem.Api.Services;
using Moq;

namespace AuctionSystem.Api.Tests.Services;

[TestClass]
public class AuctionServiceTests
{
    private Mock<IAuctionRepository> _auctionRepo = null!;
    private Mock<IUserRepository> _userRepo = null!;
    private AuctionService _service = null!;

    [TestInitialize]
    public void Setup()
    {
        _auctionRepo = new Mock<IAuctionRepository>();
        _userRepo = new Mock<IUserRepository>();
        _service = new AuctionService(_auctionRepo.Object, _userRepo.Object);
    }

    [TestMethod]
    public async Task CreateAsync_UserNotFound_ThrowsException()
    {
        _userRepo.Setup(r => r.GetByIdAsync(1))
                 .ReturnsAsync((User?)null);

        var request = new CreateAuctionRequest("TestTitle",
                                               "TestDescription",
                                               10,
                                               DateTime.UtcNow,
                                               DateTime.UtcNow.AddDays(1),
                                               "TestCategory");

        await Assert.ThrowsExactlyAsync<UserNotFoundException>(async () =>
            await _service.CreateAsync(1, request));
    }

    [TestMethod]
    public async Task CreateAsync_ValidRequest_CreatesAuction()
    {
        _userRepo.Setup(r => r.GetByIdAsync(1))
                 .ReturnsAsync(new User { Id = 1 });

        _auctionRepo.Setup(r => r.AddAsync(It.IsAny<Auction>()))
                    .Returns(Task.CompletedTask);

        _auctionRepo.Setup(r => r.SaveChangesAsync())
                    .Returns(Task.CompletedTask);

        var request = new CreateAuctionRequest("TestTitle",
                                               "TestDescription",
                                               10,
                                               DateTime.UtcNow,
                                               DateTime.UtcNow.AddDays(1),
                                               "TestCategory");

        var response = await _service.CreateAsync(1, request);

        Assert.AreEqual(request.Title, response.Title);
        Assert.AreEqual(request.Description, response.Description);
        Assert.AreEqual(request.StartingPrice, response.StartingPrice);
        Assert.AreEqual(request.StartDate, response.StartDate);
        Assert.AreEqual(request.EndDate, response.EndDate);
        Assert.AreEqual(request.Category, response.Category);
        Assert.AreEqual(1, response.OwnerId);

        _userRepo.Verify(r => r.GetByIdAsync(1), Times.Once);
        _auctionRepo.Verify(r => r.AddAsync(It.IsAny<Auction>()), Times.Once);
        _auctionRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [TestMethod]
    public async Task UpdateAsync_AuctionNotFound_ThrowsException()
    {
        _auctionRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync((Auction?)null);

        var request = new UpdateAuctionRequest("TestTitle",
                                               "TestDescription",
                                               "TestCategory",
                                               10,
                                               DateTime.UtcNow,
                                               DateTime.UtcNow.AddDays(1));

        await Assert.ThrowsExactlyAsync<AuctionNotFoundException>(async () =>
            await _service.UpdateAsync(1, 1, request));
    }

    [TestMethod]
    public async Task UpdateAsync_UserNotOwner_ThrowsException()
    {
        var auction = new Auction { Id = 1, OwnerId = 2 };

        _auctionRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(auction);

        var request = new UpdateAuctionRequest("TestTitle",
                                               "TestDescription",
                                               "TestCategory",
                                               10,
                                               DateTime.UtcNow,
                                               DateTime.UtcNow.AddDays(1));

        await Assert.ThrowsExactlyAsync<AuctionOwnershipException>(async () =>
            await _service.UpdateAsync(1, 1, request));
    }

    [TestMethod]
    public async Task UpdateAsync_ValidRequest_UpdatesAuction()
    {
        var auction = new Auction
        {
            Id = 1,
            Title = "TestOldTitle",
            Description = "TestOldDescription",
            Category = "TestCategory",
            StartingPrice = 10,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(1),
            OwnerId = 1
        };

        _auctionRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(auction);

        _auctionRepo.Setup(r => r.UpdateAsync(auction))
                    .Returns(Task.CompletedTask);

        _auctionRepo.Setup(r => r.SaveChangesAsync())
                    .Returns(Task.CompletedTask);

        var request = new UpdateAuctionRequest("TestNewTitle",
                                               "TestNewDescription",
                                               "TestNewCategory",
                                               10,
                                               DateTime.UtcNow,
                                               DateTime.UtcNow.AddDays(1));

        var response = await _service.UpdateAsync(1, 1, request);

        Assert.AreEqual(request.Title, response.Title);
        Assert.AreEqual(request.Description, response.Description);
        Assert.AreEqual(request.Category, response.Category);
        Assert.AreEqual(auction.StartingPrice, response.StartingPrice);
        Assert.AreEqual(request.StartDate, response.StartDate);
        Assert.AreEqual(request.EndDate, response.EndDate);
        Assert.AreEqual(auction.OwnerId, response.OwnerId);

        _auctionRepo.Verify(r => r.GetByIdAsync(1), Times.Once);
        _auctionRepo.Verify(r => r.UpdateAsync(auction), Times.Once);
        _auctionRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [TestMethod]
    public async Task DeleteAsync_AuctionNotFound_ThrowsException()
    {
        _auctionRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync((Auction?)null);

        await Assert.ThrowsExactlyAsync<AuctionNotFoundException>(async () =>
            await _service.DeleteAsync(1, 1));
    }

    [TestMethod]
    public async Task DeleteAsync_UserNotOwner_ThrowsException()
    {
        var auction = new Auction { Id = 1, OwnerId = 2 };

        _auctionRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(auction);

        await Assert.ThrowsExactlyAsync<AuctionOwnershipException>(async () =>
            await _service.DeleteAsync(1, 1));
    }

    [TestMethod]
    public async Task DeleteAsync_ValidId_DeletesAuction()
    {
        var auction = new Auction { Id = 1, OwnerId = 1};

        _auctionRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(auction);

        _auctionRepo.Setup(r => r.DeleteAsync(auction))
                    .Returns(Task.CompletedTask);

        _auctionRepo.Setup(r => r.SaveChangesAsync())
                    .Returns(Task.CompletedTask);

        await _service.DeleteAsync(1, 1);

        _auctionRepo.Verify(r => r.GetByIdAsync(1), Times.Once);
        _auctionRepo.Verify(r => r.DeleteAsync(auction), Times.Once);
        _auctionRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [TestMethod]
    public async Task GetByIdAsync_AuctionNotFound_ThrowsException()
    {
        _auctionRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync((Auction?)null);

        await Assert.ThrowsExactlyAsync<AuctionNotFoundException>(async () =>
            await _service.GetByIdAsync(1));
    }

    [TestMethod]
    public async Task GetByIdAsync_ValidId_ReturnsAuction()
    {
        var auction = new Auction
        {
            Id = 1,
            Title = "TestOldTitle",
            Description = "TestOldDescription",
            Category = "TestCategory",
            StartingPrice = 10,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(1),
            OwnerId = 1
        };

        _auctionRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(auction);

        var response = await _service.GetByIdAsync(1);

        Assert.AreEqual(auction.Title, response.Title);
        Assert.AreEqual(auction.Description, response.Description);
        Assert.AreEqual(auction.Category, response.Category);
        Assert.AreEqual(auction.StartingPrice, response.StartingPrice);
        Assert.AreEqual(auction.StartDate, response.StartDate);
        Assert.AreEqual(auction.EndDate, response.EndDate);
        Assert.AreEqual(auction.OwnerId, response.OwnerId);

        _auctionRepo.Verify(r => r.GetByIdAsync(1), Times.Once);
    }

    [TestMethod]
    public async Task GetAllAsync_ReturnsPagedResult()
    {
        var auctions = new List<Auction>
        {
            new() { Id = 1, Title = "A", Category = "TestACategory" },
            new() { Id = 2, Title = "B", Category = "TestACategory" }
        };

        var paged = new PagedResult<Auction>(auctions, 1, 10, 2);

        _auctionRepo.Setup(r => r.GetAllAsync(It.IsAny<AuctionQueryParameters>()))
                    .ReturnsAsync(paged);

        var query = new AuctionQueryParameters("TestACategory",
                                               null,
                                               null,
                                               "Title",
                                               true,
                                               1,
                                               10);

        var result = await _service.GetAllAsync(query);

        Assert.AreEqual(2, result.TotalCount);
        Assert.AreEqual(2, result.Items.Count());

        _auctionRepo.Verify(r => r.GetAllAsync(It.IsAny<AuctionQueryParameters>()), Times.Once);
    }
}