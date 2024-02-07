using MediatR;

namespace Application.Vehicles.ListVehicles;

internal sealed class ListVehiclesQueryHandler() : IRequestHandler<ListVehiclesQuery>
{
    public async Task Handle(ListVehiclesQuery request, CancellationToken cancellationToken)
    {
        // var vehicles = await vehicleRepository.GetAllEntitiesAsync();
    }
}