using API.Controllers.Common;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CollectionVehicleEngineTypesQueryRelated;
using Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CountVehicleEngineTypesQueryRelated;
using Application.RequestParameters.TypeRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

[Route("api/EngineTypes")]
public sealed class VehicleEngineTypesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleEngineTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleEngineTypeDto>>> GetTypes(
        [FromQuery] VehicleEngineTypeFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CollectionVehicleEngineTypesQueryRequest(requestParameters));

        return Ok(result.Value);
    }

    [HttpGet("CountItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleEngineTypeFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CountVehicleEngineTypesQueryRequest(requestParameters));

        return Ok(result.Value);
    }
}