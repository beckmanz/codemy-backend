using codemy_backend.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace codemy_backend.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ConflictException ex)
        {
            _logger.LogWarning(ex, "Conflict error occurred.");

            var problemDetails = new ProblemDetails
            {
                Title = "Conflict",
                Status = StatusCodes.Status409Conflict,
                Detail = ex.Message,
                Instance = context.Request.Path
            };

            context.Response.StatusCode = StatusCodes.Status409Conflict;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (UnauthorizedException ex)
        {
            _logger.LogWarning(ex, "Authorization error occurred.");

            var problemDetails = new ProblemDetails
            {
                Title = "Authorization Error",
                Status = StatusCodes.Status403Forbidden,
                Detail = ex.Message,
                Instance = context.Request.Path
            };

            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred.");

            var problemDetails = new ProblemDetails
            {
                Title = "An unexpected error occurred.",
                Status = StatusCodes.Status500InternalServerError,
                Detail = ex.Message,
                Instance = context.Request.Path
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}