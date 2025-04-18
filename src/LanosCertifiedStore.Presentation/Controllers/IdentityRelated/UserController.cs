using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Users;
using LanosCertifiedStore.Application.Users.Queries.VehiclesRelated.CountUserVehiclesQueryRequestRelated;
using LanosCertifiedStore.Application.Users.Queries.VehiclesRelated.GetUserVehiclesQueryRequestRelated;
using LanosCertifiedStore.Application.Users.Queries.WishlistRelated.CountUserWishlistVehiclesQueryRequestRelated;
using LanosCertifiedStore.Application.Users.Queries.WishlistRelated.GetUserWishlistQueryRequestRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Infrastructure.Authorization;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.IdentityRelated;

[Route("api/user")]
public sealed class UserController : BaseApiController
{
    [HasAccessPermission("users:read")]
    [HttpGet("wishlist")]
    [ProducesResponseType(typeof(PaginationResult<VehicleDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginationResult<VehicleDto>>> GetUserWishlist(
        [FromQuery] UserWishlistFilteringRequestParameters parameters)
    {
        var result = await Sender.Send(new GetUserWishlistQueryRequest(parameters));

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return Ok(result.Value);
    }

    [HasAccessPermission("users:read")]
    [HttpGet("wishlist/count")]
    [ProducesResponseType(typeof(PaginationResult<VehicleDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginationResult<VehicleDto>>> GetUserWishlistCount(
        [FromQuery] UserWishlistFilteringRequestParameters parameters)
    {
        var result = await Sender.Send(new CountUserWishlistVehiclesQueryRequest(parameters));

        return Ok(result.Value);
    }
    
    [HasAccessPermission("users:read")]
    [HttpGet("vehicles")]
    [ProducesResponseType(typeof(PaginationResult<VehicleDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginationResult<VehicleDto>>> GetUserVehicles(
        [FromQuery] VehicleFilteringRequestParameters parameters)
    {
        var result = await Sender.Send(new GetUserVehiclesQueryRequest(parameters));

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return Ok(result.Value);
    }

    [HasAccessPermission("users:read")]
    [HttpGet("vehicles/count")]
    [ProducesResponseType(typeof(PaginationResult<VehicleDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginationResult<VehicleDto>>> CountUserVehicles(
        [FromQuery] VehicleFilteringRequestParameters parameters)
    {
        var result = await Sender.Send(new CountUserVehiclesQueryRequest(parameters));

        return Ok(result.Value);
    }
}