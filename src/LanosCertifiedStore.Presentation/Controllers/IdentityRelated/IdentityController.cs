using API.Controllers.Common;
using Application.Identity.Commands.RegisterUserCommandRequestRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.Authorization;
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