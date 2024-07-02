namespace API.Controllers.VehicleRelated;

// public sealed class VehiclesController : BaseModelRelatedApiController
// {
//     [HttpGet]
//     [ProducesResponseType(typeof(PaginationResult<VehicleDto>), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<PaginationResult<VehicleDto>>> GetVehicles(
//         [FromQuery] VehicleFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new VehiclesQuery(requestParameters)));
//     }
//
//     [HttpGet("{id:guid}")]
//     [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<VehicleDto>> GetVehicle(Guid id)
//     {
//         return HandleResult(await Mediator.Send(new VehicleSingleQueryRequest(id)));
//     }
//     
//     [HttpGet("countItems")]
//     [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
//         [FromQuery] VehicleFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new CountVehiclesQueryRequest(requestParameters)));
//     }
//     
//     [HttpGet("getPriceRange")]
//     [ProducesResponseType(typeof(Dictionary<string, decimal>), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<Dictionary<string, decimal>>> GetPriceRange(
//         [FromQuery] VehicleFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new VehiclePriceRangeQuery(requestParameters)));
//     }
//
//     [HttpPost]
//     [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<Guid>> CreateVehicle([FromBody] CreateVehicleCommand createVehicleCommand)
//     {
//         return HandleResult(await Mediator.Send(createVehicleCommand));
//     }
//
//     [HttpPut]
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult> UpdateVehicle([FromBody] UpdateVehicleCommand updateVehicleCommand)
//     {
//         return HandleResult(await Mediator.Send(updateVehicleCommand));
//     }
//
//     [HttpDelete]
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult> DeleteVehicle([FromBody] DeleteVehicleCommand deleteVehicleCommand)
//     {
//         return HandleResult(await Mediator.Send(deleteVehicleCommand));
//     }
//
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
//     [HttpPost("addImage")]
//     public async Task<ActionResult> AddImageToVehicle([FromForm] AddImageToVehicleCommand addImageToVehicleCommand)
//     {
//         return HandleResult(await Mediator.Send(addImageToVehicleCommand));
//     }
//
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     [HttpDelete("deleteImage")]
//     public async Task<ActionResult> DeleteImageFromVehicle(
//         [FromBody] RemoveImageFromVehicleCommand removeImageFromVehicleCommand)
//     {
//         return HandleResult(await Mediator.Send(removeImageFromVehicleCommand));
//     }
//
//     [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     [HttpPost("setMainImage")]
//     public async Task<ActionResult> SetVehicleMainImage(
//         [FromBody] SetVehicleMainImageCommand setVehicleMainImageCommand)
//     {
//         return HandleResult(await Mediator.Send(setVehicleMainImageCommand));
//     }
// }