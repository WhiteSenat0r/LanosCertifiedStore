using API.Controllers.Common;
using API.Responses;
using Application.Commands.Types.VehicleDrivetrainTypeRelated.CreateDrivetrainType;
using Application.Commands.Types.VehicleDrivetrainTypeRelated.DeleteDrivetrainType;
using Application.Commands.Types.VehicleDrivetrainTypeRelated.UpdateDrivetrainType;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.Queries.Types.VehicleDrivetrainTypeRelated;
using Application.Queries.Types.VehicleDrivetrainTypeRelated.CountTransmissionTypesQueryRelated;
using Application.RequestParams.TypeRelated;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

public sealed class VehicleDrivetrainTypesController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleDrivetrainTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleDrivetrainTypeDto>>> GetTypes(
        [FromQuery] VehicleDrivetrainTypeFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new VehicleDrivetrainTypesQuery(requestParameters)));
    }
    
    [HttpGet("countItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleDrivetrainTypeFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new CountDrivetrainTypesQuery(requestParameters)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateType([FromBody] CreateDrivetrainTypeCommand createCommand)
    {
        return HandleResult(await Mediator.Send(createCommand));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateType([FromBody] UpdateDrivetrainTypeCommand updateCommand)
    {
        return HandleResult(await Mediator.Send(updateCommand));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteType([FromBody] DeleteDrivetrainTypeCommand deleteCommand)
    {
        return HandleResult(await Mediator.Send(deleteCommand));
    }
}