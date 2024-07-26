using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleEngineTypes;
using LanosCertifiedStore.Application.VehicleEngineTypes.Queries.CollectionVehicleEngineTypesQueryRelated;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.TypeRelated;

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