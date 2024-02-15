using API.Responses;
using Application.Core;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Common;

public abstract class BaseEntityRelatedApiController : BaseApiController
{
    protected override ActionResult HandleResult<T>(Result<T>? result)
    {
        if (result is null)
            return NotFound(new ApiResponse(NotFound().StatusCode));

        return result.IsSuccess switch
        {
            true when result.Value is not null => Ok(result.Value),
            true when result.Value is null => NotFound(new ApiResponse(NotFound().StatusCode)),
            _ => BadRequest(new ApiResponse(BadRequest().StatusCode, result.Error!.Message))
        };
    }
}