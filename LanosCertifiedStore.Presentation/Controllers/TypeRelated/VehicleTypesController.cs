using API.Controllers.Common;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleTypeRelated.CollectionVehicleTypesQueryRelated;
using Application.RequestParameters.Common.Enums;
using Application.RequestParameters.TypeRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

[Route("api/Types")]
public sealed class VehicleTypesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleTypeDto>>> GetTypes([FromQuery] string? sortingType)
    {
        var result = await Mediator.Send(new CollectionVehicleTypesQueryRequest(
            new VehicleTypeFilteringRequestParameters
            { 
                ItemQuantity = ItemQuantitySelection.TwentyFive,
                SortingType = sortingType ?? string.Empty
            }));

        return Ok(result.Value);
    }
}