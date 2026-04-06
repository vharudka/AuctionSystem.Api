using AuctionSystem.Api.Dtos.Auctions;
using AuctionSystem.Api.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Api.Controllers;

[ApiController]
[Route("auctions")]
public class AuctionsController : ControllerBase
{
    private readonly IAuctionService _service;
    private readonly IValidator<CreateAuctionRequest> _createValidator;
    private readonly IValidator<UpdateAuctionRequest> _updateValidator;

    public AuctionsController(IAuctionService service,
                              IValidator<CreateAuctionRequest> createValidator,
                              IValidator<UpdateAuctionRequest> updateValidator)
    {
        _service = service;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAuctionRequest request)
    {
        var validation = await _createValidator.ValidateAsync(request);
        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }

        var result = await _service.CreateAsync(request);

        return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateAuctionRequest request)
    {
        var validation = await _updateValidator.ValidateAsync(request);
        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }

        var result = await _service.UpdateAsync(id, request);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _service.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] AuctionQueryParameters query)
    {
        var result = await _service.GetAllAsync(query);

        return Ok(result);
    }
}