using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Application.Vehicles.Queries.CollectionVehiclesQueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Commands.Common;
using LanosCertifiedStore.Persistence.Commands.VehicleRelated;
using LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Vehicles;

internal sealed class VehicleService(
    CreateVehicleCommand createVehicleCommand,
    CollectionVehiclesQuery collectionVehiclesQuery,
    SaveChangesCommand saveChangesCommand) : IVehicleService
{
    public async Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        await createVehicleCommand.Execute(vehicle, cancellationToken);
        await saveChangesCommand.Execute(cancellationToken);
    }

    public async Task<IReadOnlyCollection<VehicleDto>> GetVehicles(CollectionVehiclesQueryRequest request,
        CancellationToken cancellationToken = default)
    {
        return await collectionVehiclesQuery.Execute(request, cancellationToken);
    }
}