using API.Controllers.Common;
using Application.Commands.Identity;
using Application.Commands.Identity.Login;
using Application.Commands.Identity.Register;
using Application.Dtos.IdentityDtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class IdentityController : BaseIdentityRelatedController 
{
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
    {
        return HandleResult(await Mediator.Send(new LoginCommand(loginDto)));
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
    {
        return HandleResult(await Mediator.Send(new RegisterCommand(registerDto)));
    }
}