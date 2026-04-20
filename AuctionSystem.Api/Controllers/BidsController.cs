using AuctionSystem.Api.Dtos.Bids;
using AuctionSystem.Api.Extensions;
using AuctionSystem.Api.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Api.Controllers;

[ApiController]
[Route("api/auctions/{auctionId:int}/[controller]")]
[Authorize]
public class BidsController : ControllerBase
{
    private readonly IBidService _service;
    private readonly IValidator<CreateBidRequest> _createValidator;
    private readonly IValidator<BidQueryParameters> _queryValidator;
    private readonly ILogger<BidsController> _logger;
    public BidsController(IBidService service,
                          IValidator<CreateBidRequest> createValidator,
                          IValidator<BidQueryParameters> queryValidator,
                          ILogger<BidsController> logger)
    {
        _service = service;
        _createValidator = createValidator;
        _queryValidator = queryValidator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetBidsAsync(int auctionId, [FromQuery] BidQueryParameters query)
    {
        _logger.LogInformation("Get bids request received for auction {AuctionId}", auctionId);

        var validation = await _queryValidator.ValidateAsync(query);
        if (!validation.IsValid)
        {
            _logger.LogWarning("Get bids validation failed for auction {AuctionId}: {@Errors}", auctionId, validation.Errors);
            return BadRequest(validation.Errors);
        }

        var result = await _service.GetBidsAsync(auctionId, query);

        _logger.LogInformation("Bids for auction {AuctionId} retrieved successfully", auctionId);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(int auctionId, CreateBidRequest request)
    {
        _logger.LogInformation("Create bid request received for auction {AuctionId}", auctionId);

        var validation = await _createValidator.ValidateAsync(request);
        if (!validation.IsValid)
        {
            _logger.LogWarning("Create bid validation failed for auction {AuctionId}: {@Errors}", auctionId, validation.Errors);
            return BadRequest(validation.Errors);
        }

        var userId = User.GetUserId();

        var result = await _service.CreateAsync(auctionId, userId, request);

        _logger.LogInformation("Bid {BidId} created successfully for auction {AuctionId} by user {UserId}", result.Id, auctionId, userId);

        return Created($"/api/auctions/{auctionId}/bids/{result.Id}", result);
    }
}