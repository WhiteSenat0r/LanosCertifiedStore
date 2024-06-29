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
    
    private protected static ProblemDetails CreateProblemDetails(
        string title, int status, Error error, Error[]? errors) => new()
    {
        Title = title,
        Status = status,
        Detail = error.Message,
        Extensions = { { nameof(errors), errors } }
    };
    
    private protected static ProblemDetails CreateProblemDetails(string title, int status, Error error) => new()
    {
        Title = title,
        Status = status,
        Detail = error.Message,
    };
}