﻿using System.Net;
using API.Middlewares.ExceptionRelated.Common.Classes;
using Microsoft.EntityFrameworkCore;

namespace API.Middlewares.ExceptionRelated;

internal sealed class DatabaseUpdateExceptionHandler(
    ILogger<DatabaseUpdateExceptionHandler> logger) : ExceptionHandlerBase<DbUpdateException>(
    logger,
    "ActionRejection",
    "This action can not be performed!",
    HttpStatusCode.BadRequest);