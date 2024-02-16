using API.Responses;
using Domain.Contracts.ValidationRelated;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Common;

public abstract class BaseEntityRelatedApiController : BaseApiController
{
    protected override ActionResult HandleResult<T>(Result<T>? result)
    {
        return result switch
        {
            null => NotFound(new ApiResponse(NotFound().StatusCode, null)),
            IValidationResult validationResult => BadRequest(CreateProblemDetails("Validation Error",
                BadRequest().StatusCode, result.Error!, validationResult.Errors)),
            _ => result.IsSuccess switch
            {
                true when result.Value is not null => Ok(result.Value),
                true when result.Value is null => NotFound(new ApiResponse(NotFound().StatusCode, null)),
                _ => BadRequest(new ApiResponse(BadRequest().StatusCode, result.Error!.Message))
            }
        };
    }

    private static ProblemDetails CreateProblemDetails(
        string title, int status, Error error, Error[]? errors = null) => new()
    {
        Title = title,
        Status = status,
        Type = error.Code,
        Detail = error.Message,
        Extensions = { { nameof(errors), errors } }
    };
}