using System.Net;
using LanosCertifiedStore.Presentation.Middlewares.ExceptionRelated.Common.Classes;

namespace LanosCertifiedStore.Presentation.Middlewares.ExceptionRelated;

internal sealed class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger) : ExceptionHandlerBase<Exception>(
    logger,
    HttpStatusCode.InternalServerError,
    "InternalServerError");