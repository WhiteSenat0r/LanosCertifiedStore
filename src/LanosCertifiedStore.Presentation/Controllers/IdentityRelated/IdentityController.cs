using LanosCertifiedStore.Application.Identity.Commands.AddUserFromProviderCommandRequestRelated;
using LanosCertifiedStore.Application.Identity.Commands.ChangeUserRoleCommandRequestRelated;
using LanosCertifiedStore.Application.Identity.Commands.ResetPasswordCommandRequestRelated;
using LanosCertifiedStore.Application.Identity.Commands.UpdateUserDataCommandRequestRelated;
using LanosCertifiedStore.Application.Identity.Commands.UpdateUserSelfCommandRequestRelated;
using LanosCertifiedStore.Application.Identity.Commands.UserEmailUpdateCommandRequestRelated;
using LanosCertifiedStore.Application.Identity.Queries.GetUserDataQueryRequestRelated;
using LanosCertifiedStore.Application.Shared.ValidationRelated;
using LanosCertifiedStore.Infrastructure.Authorization;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.IdentityRelated;

[Route("api/identity")]
public sealed class IdentityController : BaseApiController
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPost]
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
    [HttpGet("{id:guid}")]
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
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateUserData(Guid id, UpdateUserDataCommandRequest request)
    {
        request = request with
        {
            Id = id
        };
        
        var result = await Sender.Send(request);

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        if (result is IValidationResult validationResult)
        {
            return BadRequest(CreateValidationProblemDetails(result.Error!, validationResult.Errors));
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateSelf(UpdateUserSelfCommandRequest request)
    {
        var result = await Sender.Send(request);

        if (result is IValidationResult validationResult)
        {
            return BadRequest(CreateValidationProblemDetails(result.Error!, validationResult.Errors));
        }

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return NoContent();
    }

    [HasAccessPermission("users:change-role")]
    [HttpPut("{userId:guid}/role")]
    public async Task<ActionResult> UpdateUserRole(
        [FromRoute] Guid userId,
        [FromBody] string roleCode)
    {
        var request = new ChangeUserRoleCommandRequest(userId, roleCode);

        var result = await Sender.Send(request);

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return NoContent();
    }

    [HttpPut("email")]
    public async Task<ActionResult> UpdateEmail(UserEmailUpdateCommandRequest request)
    {
        var result = await Sender.Send(request);

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return NoContent();
    }

    [HttpPut("password")]
    public async Task<ActionResult> ResetPassword()
    {
        var result = await Sender.Send(new ResetPasswordCommandRequest());

        if (!result.IsSuccess)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }
}