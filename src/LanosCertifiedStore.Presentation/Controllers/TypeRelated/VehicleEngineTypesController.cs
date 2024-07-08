using API.Controllers.Common;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CollectionVehicleEngineTypesQueryRelated;
using Application.RequestParameters.Common.Enums;
using Application.RequestParameters.TypeRelated;
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
        var result = await Mediator.Send(new CollectionVehicleEngineTypesQueryRequest(
            new VehicleEngineTypeFilteringRequestParameters
            {
                ItemQuantity = ItemQuantitySelection.TwentyFive,
                SortingType = sortingType ?? string.Empty
            }));

        return Ok(result.Value);
    }
}