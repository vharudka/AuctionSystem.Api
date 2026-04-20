using AuctionSystem.Api.Dtos.Auctions;
using AuctionSystem.Api.Extensions;
using AuctionSystem.Api.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AuctionsController : ControllerBase
{
    private readonly IAuctionService _service;
    private readonly IValidator<CreateAuctionRequest> _createValidator;
    private readonly IValidator<UpdateAuctionRequest> _updateValidator;
    private readonly ILogger<AuctionsController> _logger;

    public AuctionsController(IAuctionService service,
                              IValidator<CreateAuctionRequest> createValidator,
                              IValidator<UpdateAuctionRequest> updateValidator,
                              ILogger<AuctionsController> logger)
    {
        _service = service;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAuctionRequest request)
    {
        _logger.LogInformation("Create auction request received");

        var validation = await _createValidator.ValidateAsync(request);
        if (!validation.IsValid)
        {
            _logger.LogWarning("Create auction validation failed: {@Errors}", validation.Errors);
            return BadRequest(validation.Errors);
        }

        var userId = User.GetUserId();

        var result = await _service.CreateAsync(userId, request);

        _logger.LogInformation("Auction {AuctionId} created successfully by user {UserId}", result.Id, userId);

        return Created($"/api/auctions/{result.Id}", result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateAuctionRequest request)
    {
        _logger.LogInformation("Update auction request received for Id {Id}", id);

        var validation = await _updateValidator.ValidateAsync(request);
        if (!validation.IsValid)
        {
            _logger.LogWarning("Update auction validation failed for Id {Id}: {@Errors}", id, validation.Errors);
            return BadRequest(validation.Errors);
        }

        var result = await _service.UpdateAsync(id, request);

        _logger.LogInformation("Auction {AuctionId} updated successfully", id);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        _logger.LogInformation("Delete auction request received for Id {Id}", id);

        await _service.DeleteAsync(id);

        _logger.LogInformation("Auction with Id {Id} deleted successfully", id);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        _logger.LogInformation("Get auction by id request received for Id {Id}", id);

        var result = await _service.GetByIdAsync(id);

        _logger.LogInformation("Auction with Id {Id} retrieved successfully", id);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] AuctionQueryParameters query)
    {
        _logger.LogInformation("Get all auctions request received");

        var result = await _service.GetAllAsync(query);

        _logger.LogInformation("Get all auctions request completed successfully with {Count} items", result.Items.Count());

        return Ok(result);
    }
}