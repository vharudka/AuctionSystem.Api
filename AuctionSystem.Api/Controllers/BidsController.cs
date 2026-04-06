using AuctionSystem.Api.Dtos;
using AuctionSystem.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Api.Controllers;

[ApiController]
[Route("api/auctions/{auctionId:int}/[controller]")]
public class BidsController : ControllerBase
{
    private readonly IBidService _service;

    public BidsController(IBidService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetForAuction(int auctionId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create(int auctionId, CreateBidDto dto)
    {
        return Ok();
    }
}