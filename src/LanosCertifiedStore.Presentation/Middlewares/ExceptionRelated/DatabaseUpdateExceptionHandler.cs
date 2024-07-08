using System.Net;
using API.Middlewares.ExceptionRelated.Common.Classes;
using Microsoft.EntityFrameworkCore;

namespace API.Middlewares.ExceptionRelated;

internal sealed class DatabaseUpdateExceptionHandler(
    ILogger<DatabaseUpdateExceptionHandler> logger) : ExceptionHandlerBase<DbUpdateException>(
    logger,
    HttpStatusCode.BadRequest,
    "ActionRejection",
    "This action can not be performed!");