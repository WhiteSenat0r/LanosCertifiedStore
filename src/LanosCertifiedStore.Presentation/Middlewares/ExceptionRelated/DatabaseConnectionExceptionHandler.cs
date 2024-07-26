using System.Net;
using LanosCertifiedStore.Presentation.Middlewares.ExceptionRelated.Common.Classes;
using Npgsql;

namespace LanosCertifiedStore.Presentation.Middlewares.ExceptionRelated;

internal sealed class DatabaseConnectionExceptionHandler(
    ILogger<DatabaseConnectionExceptionHandler> logger) : ExceptionHandlerBase<NpgsqlException>(
    logger,
    HttpStatusCode.ServiceUnavailable,
    "UnreachableDataSource",
    "Data source is unreachable at this time!");