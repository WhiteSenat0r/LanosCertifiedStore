using API.Controllers.Common;
using Application.Identity.Commands.RegisterUserCommandRequestRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.IdentityRelated;

[Route("api/identity")]
public sealed class IdentityController : BaseApiController
{
    [HttpPost("testc")]
    public async Task<ActionResult> TestC([FromQuery] string id)
    {
        return Ok();
    }

    [HttpPost("register")]
    public async Task<ActionResult<Guid>> AddUserFromIdentityProvider(
        AddUserFromProviderCommandRequest addUserFromProviderCommandRequest)
    {
        var result = await Sender.Send(addUserFromProviderCommandRequest);

        if (result.IsSuccess)
        {
            return Created();
        }

        return BadRequest(result.Error);
    }
}