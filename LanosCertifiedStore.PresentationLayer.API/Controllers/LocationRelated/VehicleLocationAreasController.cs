using API.Controllers.Common;
using API.Responses;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.LocationDtos;
using Application.Queries.Locations.LocationAreasRelated;
using Application.Queries.Locations.LocationAreasRelated.CountAreasQueryRelated;
using Application.RequestParams.LocationRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.LocationRelated;

public sealed class VehicleLocationAreasController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<AreaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<AreaDto>>> GetAreas(
        [FromQuery] VehicleLocationAreaFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new VehicleLocationAreasQuery(requestParameters)));
    }
    
    [HttpGet("countItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleLocationAreaFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new CountAreasQuery(requestParameters)));
    }
    
    // TODO Maybe add full CRUD in the future
}