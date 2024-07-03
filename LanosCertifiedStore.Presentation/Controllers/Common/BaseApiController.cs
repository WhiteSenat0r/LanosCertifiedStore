using System.Net;
using Application.Shared.ResultRelated;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => (_mediator ??=
        HttpContext.RequestServices.GetService<IMediator>())!;

    private protected abstract ActionResult HandleResult<T>(Result<T> result);

    private protected static ProblemDetails CreateValidationProblemDetails(Error error,
        Error[]? errors) => new()
    {
        Title = "ValidationError",
        Status = (int)HttpStatusCode.BadRequest,
        Detail = error.Message,
        Extensions = { { nameof(errors), errors } }
    };

    private protected static ProblemDetails CreateNotFoundProblemDetails(Error error) => new()
    {
        Title = error.Code,
        Status = (int)HttpStatusCode.NotFound,
        Detail = error.Message
    };
}