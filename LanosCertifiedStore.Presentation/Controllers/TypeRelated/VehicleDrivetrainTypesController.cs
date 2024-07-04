namespace API.Controllers.TypeRelated;

// public sealed class VehicleDrivetrainTypesController : BaseModelRelatedApiController
// {
//     [HttpGet]
//     [ProducesResponseType(typeof(PaginationResult<VehicleDrivetrainTypeDto>), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<PaginationResult<VehicleDrivetrainTypeDto>>> GetTypes(
//         [FromQuery] VehicleDrivetrainTypeFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new VehicleDrivetrainTypesQuery(requestParameters)));
//     }
//     
//     [HttpGet("countItems")]
//     [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
//         [FromQuery] VehicleDrivetrainTypeFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new CountDrivetrainTypesQueryRequest(requestParameters)));
//     }
//
//     [HttpPost]
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult> CreateVehicleTypeRelated([FromBody] CreateDrivetrainTypeCommand createCommand)
//     {
//         return HandleResult(await Mediator.Send(createCommand));
//     }
//
//     [HttpPut]
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult> UpdateVehicleTypeRelated([FromBody] UpdateDrivetrainTypeCommand updateCommand)
//     {
//         return HandleResult(await Mediator.Send(updateCommand));
//     }
//
//     [HttpDelete]
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult> DeleteType([FromBody] DeleteDrivetrainTypeCommand deleteCommand)
//     {
//         return HandleResult(await Mediator.Send(deleteCommand));
//     }
// }