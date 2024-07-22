using API.Controllers.Common;
using Application.Shared.RequestParamsRelated;
using Application.Shared.ResultRelated;
using Application.VehicleEngineTypes;
using Application.VehicleEngineTypes.Queries.CollectionVehicleEngineTypesQueryRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

[Route("api/EngineTypes")]
public sealed class VehicleEngineTypesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleEngineTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleEngineTypeDto>>> GetTypes([FromQuery] string? sortingType)
    {
        var result = await Sender.Send(new CollectionVehicleEngineTypesQueryRequest(
            new VehicleEngineTypeFilteringRequestParameters
            {
                ItemQuantity = ItemQuantitySelection.TwentyFive,
                SortingType = sortingType ?? string.Empty
            }));

        return Ok(result.Value);
    }
}