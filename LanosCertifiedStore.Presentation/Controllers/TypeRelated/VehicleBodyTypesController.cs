using API.Controllers.Common;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleBodyTypeRelated.CollectionVehicleBodyTypesQueryRelated;
using Application.QueryRequests.TypesRelated.VehicleBodyTypeRelated.CountBodyTypesQueryRelated;
using Application.RequestParameters.TypeRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

[Route("api/BodyTypes")]
public sealed class VehicleBodyTypesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleBodyTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleBodyTypeDto>>> GetTypes(
        [FromQuery] VehicleBodyTypeFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CollectionVehicleBodyTypesQueryRequest(requestParameters));

        return Ok(result.Value);
    }

    [HttpGet("countItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleBodyTypeFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CountVehicleBodyTypesQueryRequest(requestParameters));

        return Ok(result.Value);
    }
}