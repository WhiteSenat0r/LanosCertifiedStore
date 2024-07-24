using System.Net;
using API.Controllers.Common;
using Application.Identity.Commands.RegisterUserCommandRequestRelated;
using Application.Shared.ValidationRelated;
using Domain.Entities.UserRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.IdentityRelated;

[Route("api/identity")]
public sealed class IdentityController : BaseApiController
{
    [HttpGet("dummy")]
    [HasAccessPermission("users:read")]
    public async Task<ActionResult<string>> Foo()
    {
        return Ok("NIGGER");
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<Guid>> RegisterUser(RegisterUserCommandRequest registerUserCommandRequest)
    {
        var result = await Sender.Send(registerUserCommandRequest);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        if (result is IValidationResult validationResult)
        {
            return BadRequest(CreateValidationProblemDetails(result.Error!, validationResult.Errors));
        }

        var problemDetails = new ProblemDetails
        {
            Title = result.Error!.Code,
            Status = (int)HttpStatusCode.BadRequest,
            Detail = result.Error.Message,
        };
        return BadRequest(problemDetails);
    }
}