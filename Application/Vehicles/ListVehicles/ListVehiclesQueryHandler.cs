using MediatR;

namespace Application.Vehicles.ListVehicles;

public sealed class ListVehiclesQueryHandler : IRequestHandler<ListVehiclesQuery>
{
    public Task Handle(ListVehiclesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}