using API.Controllers.Common;
using Application.Identity.Commands.RegisterUserCommandRequestRelated;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.IdentityRelated;

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
}