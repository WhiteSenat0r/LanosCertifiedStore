using API.Controllers.Common;
using Application.Shared.RequestParamsRelated;
using Application.Shared.ResultRelated;
using Application.VehicleColors;
using Application.VehicleColors.Queries.CollectionVehicleColorsQueryRequestRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehicleRelated;

[Route("api/Colors")]
public sealed class VehicleColorsController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleColorDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleColorDto>>> GetColors(
        [FromQuery] string? sortingType)
    {
        var result = await Sender.Send(new CollectionVehicleColorsQueryRequest(
            new VehicleColorFilteringRequestParameters
            {
                ItemQuantity = ItemQuantitySelection.Fifty,
                SortingType = sortingType ?? string.Empty
            }));
        return Ok(result.Value);
    }
}