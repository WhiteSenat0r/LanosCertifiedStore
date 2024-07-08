using API.Controllers.Common;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.LocationDtos;
using Application.QueryRequests.LocationsRelated.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;
using Application.QueryRequests.LocationsRelated.LocationTownsRelated.CountLocationTownsQueryRelated;
using Application.RequestParameters.LocationRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.LocationRelated;

[Route("api/LocationTowns")]
public sealed class VehicleLocationTownsController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<LocationTownDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<LocationTownDto>>> GetTowns(
        [FromQuery] VehicleLocationTownFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CollectionLocationTownsQueryRequest(requestParameters));

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return Ok(result.Value);
    }
    
    [HttpGet("CountItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleLocationTownFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CountLocationTownsQueryRequest(requestParameters));

        return Ok(result.Value);
    }
}