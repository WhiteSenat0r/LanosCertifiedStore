using System.Net;
using API.Middlewares.ExceptionRelated.Common.Classes;
using Npgsql;

namespace API.Middlewares.ExceptionRelated;

internal sealed class DatabaseConnectionExceptionHandler(
    ILogger<DatabaseConnectionExceptionHandler> logger) : ExceptionHandlerBase<NpgsqlException>(
    logger,
    "UnreachableDataSource",
    "Data source is unreachable at this time!",
    HttpStatusCode.ServiceUnavailable);