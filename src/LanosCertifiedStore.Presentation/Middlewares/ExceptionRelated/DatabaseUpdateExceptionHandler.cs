using System.Net;
using LanosCertifiedStore.Presentation.Middlewares.ExceptionRelated.Common.Classes;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Presentation.Middlewares.ExceptionRelated;

internal sealed class DatabaseUpdateExceptionHandler(
    ILogger<DatabaseUpdateExceptionHandler> logger) : ExceptionHandlerBase<DbUpdateException>(
    logger,
    HttpStatusCode.BadRequest,
    "ActionRejection",
    "This action can not be performed!");