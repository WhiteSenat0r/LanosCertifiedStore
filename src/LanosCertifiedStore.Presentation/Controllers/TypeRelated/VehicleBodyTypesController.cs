using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleBodyTypes;
using LanosCertifiedStore.Application.VehicleBodyTypes.Queries.CollectionVehicleBodyTypesQueryRelated;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.TypeRelated;

[Route("api/body-types")]
public sealed class VehicleBodyTypesController : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleBodyTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleBodyTypeDto>>> GetTypes([FromQuery] string? sortingType)
    {
        var result = await Sender.Send(new CollectionVehicleBodyTypesQueryRequest(
            new VehicleBodyTypeFilteringRequestParameters
            {
                ItemQuantity = ItemQuantitySelection.TwentyFive,
                SortingType = sortingType ?? string.Empty
            }));

        return Ok(result.Value);
    }
}