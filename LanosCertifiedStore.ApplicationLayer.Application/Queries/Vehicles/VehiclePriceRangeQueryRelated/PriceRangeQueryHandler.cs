using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RepositoryRelated.VehicleRepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.VehiclePriceRangeQueryRelated;

internal sealed class VehiclePriceRangeQueryHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<VehiclePriceRangeQuery, Result<IDictionary<string, decimal>>>
{
    public async Task<Result<IDictionary<string, decimal>>> Handle(VehiclePriceRangeQuery request,
        CancellationToken cancellationToken)
    {
        var repository = unitOfWork.RetrieveRepository<Vehicle>();

        var priceRange = await (repository as IVehicleRepositoryExtensions)!
            .GetPriceRange(request.RequestParameters);

        return Result<IDictionary<string, decimal>>.Success(priceRange);
    }
}