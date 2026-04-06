using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Api.Controllers;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new { status = "API is running" });
}