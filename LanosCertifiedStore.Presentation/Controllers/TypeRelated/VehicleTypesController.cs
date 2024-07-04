using API.Controllers.Common;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleTypeRelated.CollectionVehicleTypesQueryRelated;
using Application.QueryRequests.TypesRelated.VehicleTypeRelated.CountVehicleTypesQueryRelated;
using Application.RequestParameters.TypeRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

[Route("api/[controller]")]
public sealed class VehicleTypesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleTypeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginationResult<VehicleTypeDto>>> GetTypes(
        [FromQuery] VehicleTypeFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CollectionVehicleTypesQueryRequest(requestParameters));

        return Ok(result.Value);
    }

    [HttpGet("CountItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleTypeFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CountVehicleTypesQueryRequest(requestParameters));

        return Ok(result.Value);
    }
}