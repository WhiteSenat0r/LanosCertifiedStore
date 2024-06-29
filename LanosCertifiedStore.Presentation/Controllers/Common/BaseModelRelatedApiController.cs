using System.Net;
using Application.Contracts.ValidationRelated;
using Application.Shared.ResultRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Common;

public abstract class BaseModelRelatedApiController : BaseApiController
{
    private protected override ActionResult HandleResult<T>(Result<T>? result)
    {
        return result switch
        {
            null => NotFound(GetNotFoundResult()),
            IValidationResult validationResult => BadRequest(CreateProblemDetails(
                "ValidationError", (int)HttpStatusCode.BadRequest, result.Error!, validationResult.Errors)),
            _ => result.IsSuccess switch
            {
                true when result.Value is not null => Ok(result.Value),
                true when result.Value is null => NotFound(GetNotFoundResult()),
                _ => BadRequest(CreateProblemDetails("BadRequestResult", (int)HttpStatusCode.BadRequest, result.Error!))
            }
        };
    }

    private ProblemDetails GetNotFoundResult() => CreateProblemDetails(
        "NotFoundRequestResult",
        (int)HttpStatusCode.NotFound,
        new Error("NotFoundRequestResult", "Nothing was found after request execution!"));
}