using System.Net;
using API.Middlewares.ExceptionRelated.Common.Classes;
using Application.Shared.ExceptionRelated;

namespace API.Middlewares.ExceptionRelated;

internal sealed class ValidationExceptionHandler(
    ILogger<ValidationExceptionHandler> logger) : ExceptionHandlerBase<ValidationException>(
    logger,
    HttpStatusCode.BadRequest,
    "ValidationError");