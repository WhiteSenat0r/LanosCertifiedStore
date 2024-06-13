using Application.Shared;
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

    protected abstract ActionResult HandleResult<T>(Result<T> result);
    
    protected static ProblemDetails CreateProblemDetails(
        string title, int status, Error error, Error[]? errors = null) => new()
    {
        Title = title,
        Status = status,
        Type = error.Code,
        Detail = error.Message,
        Extensions = { { nameof(errors), errors } }
    };
}