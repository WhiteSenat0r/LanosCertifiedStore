using LanosCertifiedStore.Application.LocationRegions;
using LanosCertifiedStore.Application.LocationRegions.Dtos;
using LanosCertifiedStore.Application.LocationRegions.Queries.CollectionLocationRegionsQueryRequestRelated;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.LocationRelated;

[Route("api/LocationRegions")]
public sealed class VehicleLocationRegionsController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<LocationRegionDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<LocationRegionDto>>> GetRegions(
        [FromQuery] string? sortingType)
    {
        var result = await Sender.Send(new CollectionLocationRegionsQueryRequest(
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