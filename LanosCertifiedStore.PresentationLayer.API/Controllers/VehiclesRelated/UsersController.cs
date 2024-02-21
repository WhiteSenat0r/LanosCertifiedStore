using API.Controllers.Common;
using API.Responses;
using Application.Commands.Identity.UserManagement.DeleteUser;
using Application.Core.Results;
using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Application.Dtos.IdentityDtos.ProfileDtos;
using Application.Queries.Users.ListUsers;
using Application.Queries.Users.UserDetails;
using Application.RequestParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class UsersController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IReadOnlyList<ProfileDto>>> GetUsers(
        [FromQuery] UserFilteringRequestParameters userFilteringRequestParameters)
    {
        return HandleResult(await Mediator.Send(new ListUsersQuery(userFilteringRequestParameters)));
    }

    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProfileDto>> GetUser(Guid id)
    {
        return HandleResult(await Mediator.Send(new UserDetailsQuery(id)));
    }

    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteUserCommand(id)));
    }
}