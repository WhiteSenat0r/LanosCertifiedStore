namespace API.Controllers.TypeRelated;

// public sealed class VehicleEngineTypesController : BaseModelRelatedApiController
// {
//     [HttpGet]
//     [ProducesResponseType(typeof(PaginationResult<VehicleEngineTypeDto>), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<PaginationResult<VehicleEngineTypeDto>>> GetTypes(
//         [FromQuery] VehicleEngineTypeFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new VehicleEngineTypesQuery(requestParameters)));
//     }
//     
//     [HttpGet("countItems")]
//     [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
//         [FromQuery] VehicleEngineTypeFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new CountEngineTypesQueryRequest(requestParameters)));
//     }
//
//     [HttpPost]
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult> CreateVehicleTypeRelated([FromBody] CreateEngineTypeCommand createCommand)
//     {
//         return HandleResult(await Mediator.Send(createCommand));
//     }
//
//     [HttpPut]
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult> UpdateVehicleTypeRelated([FromBody] UpdateEngineTypeCommand updateCommand)
//     {
//         return HandleResult(await Mediator.Send(updateCommand));
//     }
//
//     [HttpDelete]
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult> DeleteType([FromBody] DeleteEngineTypeCommand deleteCommand)
//     {
//         return HandleResult(await Mediator.Send(deleteCommand));
//     }
// }