using API.Controllers.Common;
using API.Responses;
using Application.Commands.Types.VehicleTypeRelated.CreateType;
using Application.Commands.Types.VehicleTypeRelated.DeleteType;
using Application.Commands.Types.VehicleTypeRelated.UpdateType;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.Queries.Types.VehicleTypeRelated;
using Application.Queries.Types.VehicleTypeRelated.CountTypesQueryRelated;
using Application.RequestParams.TypeRelated;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

public sealed class VehicleTypesController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleTypeDto>>> GetTypes(
        [FromQuery] VehicleTypeFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new VehicleTypesQuery(requestParameters)));
    }
    
    [HttpGet("countItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleTypeFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new CountTypesQuery(requestParameters)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateType([FromBody] CreateTypeCommand createCommand)
    {
        return HandleResult(await Mediator.Send(createCommand));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateType([FromBody] UpdateTypeCommand updateCommand)
    {
        return HandleResult(await Mediator.Send(updateCommand));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteType([FromBody] DeleteTypeCommand deleteCommand)
    {
        return HandleResult(await Mediator.Send(deleteCommand));
    }
}