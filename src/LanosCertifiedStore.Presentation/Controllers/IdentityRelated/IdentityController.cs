using System.Xml.XPath;
using API.Controllers.Common;
using Application.Identity.Commands.RegisterUserCommandRequestRelated;
using Application.Shared.ValidationRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.IdentityRelated;

[Route("api/identity")]
public sealed class IdentityController : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<Guid>> RegisterUser(RegisterUserCommandRequest registerUserCommandRequest)
    {
        var result = await Sender.Send(registerUserCommandRequest);

        if (result is IValidationResult validationResult)
        {
            return BadRequest(CreateValidationProblemDetails(result.Error!, validationResult.Errors));
        }

        if (!result.IsSuccess)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }
}