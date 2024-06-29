using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Middlewares.ExceptionRelated.Common.Classes;

internal abstract class ExceptionHandlerBase<TException>(
    ILogger<ExceptionHandlerBase<TException>> logger,
    string title,
    string detail,
    HttpStatusCode statusCode) : IExceptionHandler
    where TException : Exception
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not TException) return false;
        
        logger.LogError(
            exception, "Exception occurred: {Message}", exception.Message);

        var problemDetails = new ProblemDetails
        {
            Title = title,
            Status = (int)statusCode,
            Detail = detail
        };

        httpContext.Response.StatusCode = (int)statusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}