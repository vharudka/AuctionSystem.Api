using AuctionSystem.Api.Domain.Exceptions;

namespace AuctionSystem.Api;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";

            switch (ex)
            {
                case UsernameAlreadyExistsException:
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    break;

                case UserNotFoundException:
                case AuctionNotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;

                case BidTooLowException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;

                default:
                    _logger.LogError(ex, "Unhandled exception");
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var result = new
            {
                error = ex.Message
            };

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}