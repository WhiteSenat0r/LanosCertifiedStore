using API.Controllers.Common;
using Application.Core.Results;
using Application.Dtos.ColorDtos;
using Application.QueryRequests.VehicleColorsRelated.CollectionVehicleColorsQueryRequestRelated;
using Application.RequestParameters;
using Application.RequestParameters.Common.Enums;
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
        var result = await Mediator.Send(new CollectionVehicleColorsQueryRequest(
            new VehicleColorFilteringRequestParameters
            {
                ItemQuantity = ItemQuantitySelection.Fifty,
                SortingType = sortingType ?? string.Empty
            }));
        return Ok(result.Value);
    }
}