namespace LanosCertifiedStore.Application.Vehicles.Queries.VehiclePriceRangeQueryRelated;

// TODO
// internal sealed class VehiclePriceRangeQueryHandler(IUnitOfWork unitOfWork) :
//     IRequestHandler<VehiclePriceRangeQuery, Result<IDictionary<string, decimal>>>
// {
//     public async Task<Result<IDictionary<string, decimal>>> Handle(VehiclePriceRangeQuery request,
//         CancellationToken cancellationToken)
//     {
//         var repository = unitOfWork.RetrieveRepository<Vehicle>();
//
//         var priceRange = await (repository as IVehicleRepositoryExtensions)!
//             .GetPriceRange(request.RequestParameters);
//
//         return Result<IDictionary<string, decimal>>.Success(priceRange);
//     }
// }