using API.Controllers.Common;
using API.Responses;
using Application.Commands.Types.VehicleTransmissionTypeRelated.CreateTransmissionType;
using Application.Commands.Types.VehicleTransmissionTypeRelated.DeleteTransmissionType;
using Application.Commands.Types.VehicleTransmissionTypeRelated.UpdateTransmissionType;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.Queries.Types.VehicleTransmissionTypeRelated;
using Application.Queries.Types.VehicleTransmissionTypeRelated.CountTransmissionTypesQueryRelated;
using Application.RequestParams.TypeRelated;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

public sealed class VehicleTransmissionTypesController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleTransmissionTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleTransmissionTypeDto>>> GetTypes(
        [FromQuery] VehicleTransmissionTypeFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new VehicleTransmissionTypesQuery(requestParameters)));
    }
    
    [HttpGet("countItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleTransmissionTypeFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new CountTransmissionTypesQuery(requestParameters)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateType([FromBody] CreateTransmissionTypeCommand createCommand)
    {
        return HandleResult(await Mediator.Send(createCommand));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateType([FromBody] UpdateTransmissionTypeCommand updateCommand)
    {
        return HandleResult(await Mediator.Send(updateCommand));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteType([FromBody] DeleteTransmissionTypeCommand deleteCommand)
    {
        return HandleResult(await Mediator.Send(deleteCommand));
    }
}