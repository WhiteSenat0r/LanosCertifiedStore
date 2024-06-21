namespace API.Controllers.TypeRelated;

// public sealed class VehicleTransmissionTypesController : BaseEntityRelatedApiController
// {
//     [HttpGet]
//     [ProducesResponseType(typeof(PaginationResult<VehicleTransmissionTypeDto>), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<PaginationResult<VehicleTransmissionTypeDto>>> GetTypes(
//         [FromQuery] VehicleTransmissionTypeFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new VehicleTransmissionTypesQuery(requestParameters)));
//     }
//     
//     [HttpGet("countItems")]
//     [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
//         [FromQuery] VehicleTransmissionTypeFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new CountTransmissionTypesQuery(requestParameters)));
//     }
//
//     [HttpPost]
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult> CreateType([FromBody] CreateTransmissionTypeCommand createCommand)
//     {
//         return HandleResult(await Mediator.Send(createCommand));
//     }
//
//     [HttpPut]
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult> UpdateType([FromBody] UpdateTransmissionTypeCommand updateCommand)
//     {
//         return HandleResult(await Mediator.Send(updateCommand));
//     }
//
//     [HttpDelete]
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult> DeleteType([FromBody] DeleteTransmissionTypeCommand deleteCommand)
//     {
//         return HandleResult(await Mediator.Send(deleteCommand));
//     }
// }