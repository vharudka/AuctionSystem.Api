using AuctionSystem.Api.Dtos.Bids;
using AuctionSystem.Api.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Api.Controllers;

[ApiController]
[Route("api/auctions/{auctionId:int}/[controller]")]
public class BidsController : ControllerBase
{
    private readonly IBidService _service;
    private readonly IValidator<CreateBidRequest> _createValidator;
    private readonly IValidator<BidQueryParameters> _queryValidator;

    public BidsController(IBidService service,
                          IValidator<CreateBidRequest> createValidator,
                          IValidator<BidQueryParameters> queryValidator)
    {
        _service = service;
        _createValidator = createValidator;
        _queryValidator = queryValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetBidsAsync(int auctionId, [FromQuery] BidQueryParameters query)
    {
        var validation = await _queryValidator.ValidateAsync(query);
        if (!validation.IsValid)
            return BadRequest(validation.Errors);

        var result = await _service.GetBidsAsync(auctionId, query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(int auctionId, CreateBidRequest request)
    {
        var validation = await _createValidator.ValidateAsync(request);
        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }

        var result = await _service.CreateAsync(auctionId, request);

        return Ok(result);
    }
}