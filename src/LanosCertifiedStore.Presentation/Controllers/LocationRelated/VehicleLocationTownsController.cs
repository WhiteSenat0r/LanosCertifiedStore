using LanosCertifiedStore.Application.LocationTowns;
using LanosCertifiedStore.Application.LocationTowns.Dtos;
using LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;
using LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CountLocationTownsQueryRelated;
using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.LocationRelated;

[Route("api/LocationTowns")]
public sealed class VehicleLocationTownsController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<LocationTownDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<LocationTownDto>>> GetTowns(
        [FromQuery] VehicleLocationTownFilteringRequestParameters requestParameters)
    {
        var result = await Sender.Send(new CollectionLocationTownsQueryRequest(requestParameters));

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
        var result = await Sender.Send(new CountLocationTownsQueryRequest(requestParameters));

        return Ok(result.Value);
    }
}