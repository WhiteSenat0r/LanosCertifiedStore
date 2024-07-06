using API.Controllers.Common;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.LocationDtos;
using Application.QueryRequests.Locations.LocationAreasRelated.CollectionLocationAreasQueryRequestRelated;
using Application.QueryRequests.Locations.LocationAreasRelated.CountLocationAreasQueryRequestRelated;
using Application.RequestParameters.LocationRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.LocationRelated;

[Route("api/locationAreas")]
public sealed class VehicleLocationAreasController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<LocationAreaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<LocationAreaDto>>> GetAreas(
        [FromQuery] VehicleLocationAreaFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CollectionLocationAreasQueryRequest(requestParameters));

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return Ok(result.Value);
    }

    [HttpGet("countItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleLocationAreaFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CountLocationAreasQueryRequest(requestParameters));

        return Ok(result.Value);
    }
}