using AuctionSystem.Api.Dtos;
using AuctionSystem.Api.Services;
using Azure.Core;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    private readonly IValidator<CreateUserRequest> _createValidator;
    private readonly IValidator<UpdateUserRequest> _updateValidator;
    private readonly IValidator<UserQueryParameters> _queryValidator;

    public UsersController(IUserService service,
                           IValidator<CreateUserRequest> createValidator,
                           IValidator<UpdateUserRequest> updateValidator,
                           IValidator<UserQueryParameters> queryValidator)
    {
        _service = service;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _queryValidator = queryValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? search,
        [FromQuery] string? sortBy,
        [FromQuery] bool desc = false,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var query = new UserQueryParameters(search, sortBy, desc, page, pageSize);

        var validation = await _queryValidator.ValidateAsync(query);
        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }

        var result = await _service.GetAllAsync(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);

        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request)
    {
        var validation = await _createValidator.ValidateAsync(request);

        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }

        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserRequest request)
    {
        var validation = await _updateValidator.ValidateAsync(request);

        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }

        var result = await _service.UpdateAsync(id, request);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        return deleted ? NoContent() : NotFound();
    }
}