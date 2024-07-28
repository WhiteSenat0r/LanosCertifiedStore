using LanosCertifiedStore.Application.Identity.Commands.AddUserFromProviderCommandRequestRelated;
using LanosCertifiedStore.Application.Identity.Commands.UpdateUserDataCommandRequestRelated;
using LanosCertifiedStore.Application.Identity.Commands.UpdateUserSelfCommandRequestRelated;
using LanosCertifiedStore.Application.Identity.Commands.UserEmailUpdateCommandRequestRelated;
using LanosCertifiedStore.Application.Identity.Queries.GetUserDataQueryRequestRelated;
using LanosCertifiedStore.Infrastructure.Authorization;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.IdentityRelated;

[Route("api/identity")]
public sealed class IdentityController : BaseApiController
{
    [AllowAnonymous]
    [HttpPost("addUserFromProvider")]
    public async Task<ActionResult<Guid>> AddUserFromIdentityProvider([FromQuery] string id)
    {
        var isSuccessfulIdParse = Guid.TryParse(id, out var parsedId);

        if (!isSuccessfulIdParse)
        {
            return BadRequest("ID is not valid!");
        }

        var result = await Sender.Send(new AddUserFromProviderCommandRequest(parsedId));

        if (result.IsSuccess)
        {
            return Created();
        }

        return BadRequest(result.Error);
    }

    [HasAccessPermission("users:read")]
    [HttpGet("getUserData/{id:guid}")]
    public async Task<ActionResult> GetUserData(Guid id)
    {
        var result = await Sender.Send(new GetUserDataQueryRequest(id));

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return Ok(result.Value);
    }

    [HasAccessPermission("users:update")]
    [HttpPut("updateUserData")]
    public async Task<ActionResult> UpdateUserData(UpdateUserDataCommandRequest request)
    {
        var result = await Sender.Send(request);

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return NoContent();
    }

    [HttpPut("updateSelf")]
    public async Task<ActionResult> UpdateSelf(UpdateUserSelfCommandRequest request)
    {
        var result = await Sender.Send(request);

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return NoContent();
    }
    
    // TODO Fix mailing
    [HttpPut("updateEmail")]
    public async Task<ActionResult> UpdateEmail(UserEmailUpdateCommandRequest request)
    {
        var result = await Sender.Send(request);

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return NoContent();
    }
}