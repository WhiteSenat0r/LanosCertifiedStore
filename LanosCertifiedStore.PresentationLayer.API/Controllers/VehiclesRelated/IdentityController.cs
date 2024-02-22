using API.Controllers.Common;
using API.Responses;
using Application.Commands.Identity.Authentication.AuthenticationStatus;
using Application.Commands.Identity.Authentication.Login;
using Application.Commands.Identity.Authentication.Register;
using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class IdentityController : BaseIdentityRelatedController
{
    [HttpPost("login")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
    {
        return HandleResult(await Mediator.Send(new LoginCommand(loginDto, Response)));
    }
    
    [HttpGet("authenticationStatus")]
    [ProducesResponseType(typeof(Dictionary<string, bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Dictionary<string, bool>>> GetAuthenticationStatus()
    {
        return HandleResult(await Mediator.Send(new AuthenticationStatusCommand(Request)));
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
    {
        return HandleResult(await Mediator.Send(new RegisterCommand(registerDto)));
    }
}