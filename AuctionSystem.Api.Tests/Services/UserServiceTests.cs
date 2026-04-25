using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Domain.Exceptions;
using AuctionSystem.Api.Dtos.Users;
using AuctionSystem.Api.Infrastructure.Repositories;
using AuctionSystem.Api.Services;
using Moq;

namespace AuctionSystem.Api.Tests.Services;

[TestClass]
public class UserServiceTests
{
    private Mock<IUserRepository> _repoMock = null!;
    private UserService _service = null!;

    [TestInitialize]
    public void Setup()
    {
        _repoMock = new Mock<IUserRepository>();
        _service = new UserService(_repoMock.Object);
    }

    [TestMethod]
    public async Task GetByIdAsync_UserExists_ReturnsUserResponse()
    {
        var user = new User
        {
            Id = 1,
            Username = "TestUsername",
            Name = "TestName",
            Surname = "TestSurname"
        };

        _repoMock.Setup(r => r.GetByIdAsync(1))
                 .ReturnsAsync(user);

        var result = await _service.GetByIdAsync(1);

        Assert.IsNotNull(result);
        Assert.AreEqual(user.Id, result.Id);
        Assert.AreEqual(user.Username, result.Username);
        Assert.AreEqual(user.Name, result.Name);
        Assert.AreEqual(user.Surname, result.Surname);

        _repoMock.Verify(r => r.GetByIdAsync(1), Times.Once);
    }

    [TestMethod]
    public async Task GetByIdAsync_UserNotFound_ThrowsException()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1))
                 .ReturnsAsync((User?)null);

        await Assert.ThrowsExactlyAsync<UserNotFoundException>(async () =>
            await _service.GetByIdAsync(1));
    }

    [TestMethod]
    public async Task CreateAsync_UsernameExists_ThrowsException()
    {
        _repoMock.Setup(r => r.GetByUsernameAsync("TestUsername"))
                 .ReturnsAsync(new User());

        var request = new CreateUserRequest("TestUsername",
                                            "TestName",
                                            "TestSurname",
                                            "pass");

        await Assert.ThrowsExactlyAsync<UsernameAlreadyExistsException>(async () =>
            await _service.CreateAsync(request));
    }

    [TestMethod]
    public async Task CreateAsync_ValidUser_CreatesUser()
    {
        _repoMock.Setup(r => r.GetByUsernameAsync("TestUsername"))
                 .ReturnsAsync((User?)null);

        _repoMock.Setup(r => r.AddAsync(It.IsAny<User>()))
                 .Returns(Task.CompletedTask);

        _repoMock.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

        var request = new CreateUserRequest("TestUsername",
                                            "TestName",
                                            "TestSurname",
                                            "pass");

        var result = await _service.CreateAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(request.Username, result.Username);
        Assert.AreEqual(request.Name, result.Name);
        Assert.AreEqual(request.Surname, result.Surname);

        _repoMock.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
        _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [TestMethod]
    public async Task UpdateAsync_UserNotFound_ThrowsException()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((User?)null);

        var request = new UpdateUserRequest("TestName", "TestSurname", null);

        await Assert.ThrowsExactlyAsync<UserNotFoundException>(async () =>
            await _service.UpdateAsync(1, request));
    }

    [TestMethod]
    public async Task UpdateAsync_ValidUser_UpdatesFields()
    {
        var user = new User
        {
            Id = 1,
            Username = "TestUsername",
            Name = "TestOldName",
            Surname = "TestOldSurname",
            PasswordHash = "oldhash"
        };

        _repoMock.Setup(r => r.GetByIdAsync(1))
                 .ReturnsAsync(user);
        _repoMock.Setup(r => r.UpdateAsync(user))
                 .Returns(Task.CompletedTask);
        _repoMock.Setup(r => r.SaveChangesAsync())
                 .Returns(Task.CompletedTask);

        var request = new UpdateUserRequest("TestNewName", "TestNewSurname", "newpass");

        var result = await _service.UpdateAsync(1, request);

        Assert.IsNotNull(result);
        Assert.AreEqual(request.Name, result.Name);
        Assert.AreEqual(request.Surname, result.Surname);
        Assert.AreNotEqual("oldhash", user.PasswordHash);

        _repoMock.Verify(r => r.GetByIdAsync(1), Times.Once);
        _repoMock.Verify(r => r.UpdateAsync(user), Times.Once);
        _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [TestMethod]
    public async Task DeleteAsync_UserNotFound_ThrowsException()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((User?)null);

        var request = new UpdateUserRequest("TestName", "TestSurname", null);

        await Assert.ThrowsExactlyAsync<UserNotFoundException>(async () =>
            await _service.UpdateAsync(1, request));
    }

    [TestMethod]
    public async Task DeleteAsync_UserExists_DeletesUser()
    {
        var user = new User { Id = 1 };

        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(user);
        _repoMock.Setup(r => r.DeleteAsync(user)).Returns(Task.CompletedTask);
        _repoMock.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

        await _service.DeleteAsync(1);

        _repoMock.Verify(r => r.GetByIdAsync(1), Times.Once);
        _repoMock.Verify(r => r.DeleteAsync(user), Times.Once);
        _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}