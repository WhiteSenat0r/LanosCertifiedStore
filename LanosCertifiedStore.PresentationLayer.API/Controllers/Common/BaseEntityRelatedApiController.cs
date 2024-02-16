using API.Responses;
using Application.Core;
using Domain.Contracts.ValidationRelated;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Common;

public abstract class BaseEntityRelatedApiController : BaseApiController
{
    protected override ActionResult HandleResult<T>(Result<T>? result)
    {
        if (result is null)
            return NotFound(new ApiResponse(NotFound().StatusCode));

        if (result is IValidationResult validationResult)
            return BadRequest(CreateProblemDetails(
                "Validation Error",
                BadRequest().StatusCode,
                result.Error!,
                validationResult.Errors
            ));

        return result.IsSuccess switch
        {
            true when result.Value is not null => Ok(result.Value),
            true when result.Value is null => NotFound(new ApiResponse(NotFound().StatusCode)),
            _ => BadRequest(new ApiResponse(BadRequest().StatusCode, result.Error!.Message))
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