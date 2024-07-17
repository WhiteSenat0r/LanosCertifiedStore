using API.Controllers.Common;
using Application.Shared.RequestParamsRelated;
using Application.Shared.ResultRelated;
using Application.VehicleBodyTypes;
using Application.VehicleBodyTypes.Queries.CollectionVehicleBodyTypesQueryRelated;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

[Authorize]
[Route("api/BodyTypes")]
public sealed class VehicleBodyTypesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleBodyTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleBodyTypeDto>>> GetTypes([FromQuery] string? sortingType)
    {
        var result = await Mediator.Send(new CollectionVehicleBodyTypesQueryRequest(
            new VehicleBodyTypeFilteringRequestParameters
            {
                ItemQuantity = ItemQuantitySelection.TwentyFive,
                SortingType = sortingType ?? string.Empty
            }));

        return Ok(result.Value);
    }
}