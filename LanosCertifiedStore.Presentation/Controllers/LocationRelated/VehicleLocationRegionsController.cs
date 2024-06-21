namespace API.Controllers.LocationRelated;

// public sealed class VehicleLocationRegionsController : BaseEntityRelatedApiController
// {
//     [HttpGet]
//     [ProducesResponseType(typeof(PaginationResult<RegionDto>), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<PaginationResult<RegionDto>>> GetRegions(
//         [FromQuery] VehicleLocationRegionFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new VehicleLocationRegionsQuery(requestParameters)));
//     }
//     
//     [HttpGet("countItems")]
//     [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
//     [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
//         [FromQuery] VehicleLocationRegionFilteringRequestParameters requestParameters)
//     {
//         return HandleResult(await Mediator.Send(new CountRegionsQuery(requestParameters)));
//     }
//     
//     // TODO Maybe add full CRUD in the future
// }