// using API.Controllers.Common;
// using API.Responses;
// using Application.CommandRequests.Identity.UserManagement.DeleteUser;
// using Application.Core.Results;
// using Application.Dtos.Common;
// using Application.Dtos.IdentityDtos.ProfileDtos;
// using Application.QueryRequests.Users.CountUsers;
// using Application.QueryRequests.Users.ListUsers;
// using Application.QueryRequests.Users.UserDetails;
// using Application.RequestParameters;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
//
// namespace API.Controllers.IdentityRelated;
//
// public sealed class UsersController : BaseModelRelatedApiController
// {
//     [HttpGet]
//     [ProducesResponseType(typeof(PaginationResult<ProfileDto>), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<PaginationResult<ProfileDto>>> GetUsers(
//         [FromQuery] UserFilteringRequestParameters userFilteringRequestParameters)
//     {
//         return HandleResult(await Mediator.Send(new ListUsersQuery(userFilteringRequestParameters)));
//     }
//
//     [ProducesResponseType(typeof(ProfileDto), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     [HttpGet("{id:guid}")]
//     public async Task<ActionResult<ProfileDto>> GetUser(Guid id)
//     {
//         return HandleResult(await Mediator.Send(new UserDetailsQuery(id)));
//     }
//
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     [HttpDelete("{id:guid}")]
//     public async Task<ActionResult> DeleteUser(Guid id)
//     {
//         return HandleResult(await Mediator.Send(new DeleteUserCommand(id)));
//     }
//
//     [HttpGet("count")]
//     [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
//     public async Task<ActionResult<ItemsCountDto>> GetUsersCount(UserFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new CountUsersQuery(requestParameters)));
//     }
// }