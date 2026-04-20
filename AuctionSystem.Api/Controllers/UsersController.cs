using AuctionSystem.Api.Dtos.Users;
using AuctionSystem.Api.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    private readonly IValidator<CreateUserRequest> _createValidator;
    private readonly IValidator<UpdateUserRequest> _updateValidator;
    private readonly IValidator<UserQueryParameters> _queryValidator;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserService service,
                           IValidator<CreateUserRequest> createValidator,
                           IValidator<UpdateUserRequest> updateValidator,
                           IValidator<UserQueryParameters> queryValidator,
                           ILogger<UsersController> logger)
    {
        _service = service;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _queryValidator = queryValidator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] UserQueryParameters query)
    {
        _logger.LogInformation("Get all users request received");

        var validation = await _queryValidator.ValidateAsync(query);
        if (!validation.IsValid)
        {
            _logger.LogWarning("Get all users validation failed: {@Errors}", validation.Errors);
            return BadRequest(validation.Errors);
        }

        var result = await _service.GetAllAsync(query);

        _logger.LogInformation("Get all users request completed successfully");

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        _logger.LogInformation("Get user by id request received for Id {Id}", id);

        var result = await _service.GetByIdAsync(id);

        _logger.LogInformation("User with Id {Id} retrieved successfully", id);

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUserRequest request)
    {
        _logger.LogInformation("Create user request received");

        var validation = await _createValidator.ValidateAsync(request);

        if (!validation.IsValid)
        {
            _logger.LogWarning("User creation validation failed: {@Errors}", validation.Errors);
            return BadRequest(validation.Errors);
        }

        var result = await _service.CreateAsync(request);

        _logger.LogInformation("User created successfully with Id {UserId}", result.Id);

        return Created("/api/users/me", result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateUserRequest request)
    {
        _logger.LogInformation("Update user request received for Id {Id}", id);

        var validation = await _updateValidator.ValidateAsync(request);
        if (!validation.IsValid)
        {
            _logger.LogWarning("Update user validation failed for Id {Id}: {@Errors}", id, validation.Errors);
            return BadRequest(validation.Errors);
        }

        var result = await _service.UpdateAsync(id, request);

        _logger.LogInformation("User with Id {Id} updated successfully", id);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        _logger.LogInformation("Delete user request received for Id {Id}", id);

        await _service.DeleteAsync(id);

        _logger.LogInformation("User with Id {Id} deleted successfully", id);

        return NoContent();
    }
}