namespace API.Controllers.LocationRelated;

// public sealed class VehicleLocationTownsController : BaseEntityRelatedApiController
// {
//     [HttpGet]
//     [ProducesResponseType(typeof(PaginationResult<TownDto>), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<PaginationResult<TownDto>>> GetTowns(
//         [FromQuery] VehicleLocationTownFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new VehicleLocationTownsQuery(requestParameters)));
//     }
//     
//     [HttpGet("countItems")]
//     [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
//         [FromQuery] VehicleLocationTownFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new CountTownsQuery(requestParameters)));
//     }
//     
//     // TODO Maybe add full CRUD in the future
// }