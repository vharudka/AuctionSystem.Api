using AuctionSystem.Api.Dtos;
using AuctionSystem.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Create(CreateUserDto dto)
    {
        return Ok();
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateUserDto dto)
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }
}