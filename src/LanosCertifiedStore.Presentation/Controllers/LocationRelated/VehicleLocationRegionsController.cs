using API.Controllers.Common;
using Application.Dtos.LocationDtos;
using Application.QueryRequests.LocationsRelated.LocationRegionsRelated.CollectionLocationRegionsQueryRequestRelated;
using Application.RequestParameters.Common.Enums;
using Application.RequestParameters.LocationRelated;
using Application.Shared.ResultRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.LocationRelated;

[Route("api/LocationRegions")]
public sealed class VehicleLocationRegionsController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<LocationRegionDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<LocationRegionDto>>> GetRegions(
        [FromQuery] string? sortingType)
    {
        var result = await Mediator.Send(new CollectionLocationRegionsQueryRequest(
            new VehicleLocationRegionFilteringRequestParameters 
            {
                ItemQuantity = ItemQuantitySelection.Fifty,
                SortingType = sortingType ?? string.Empty
            }));

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return Ok(result.Value);
    }
}