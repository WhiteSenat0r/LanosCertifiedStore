using System.Net;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.Common;

[ApiController]
public abstract class BaseApiController : ControllerBase
{
    private ISender? _sender;

    protected ISender Sender => (_sender ??=
        HttpContext.RequestServices.GetService<ISender>())!;


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