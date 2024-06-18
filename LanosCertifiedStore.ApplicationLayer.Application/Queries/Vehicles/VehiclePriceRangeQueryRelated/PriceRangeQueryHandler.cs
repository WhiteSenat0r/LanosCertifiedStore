using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RepositoryRelated.VehicleRepositoryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Vehicles.VehiclePriceRangeQueryRelated;

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