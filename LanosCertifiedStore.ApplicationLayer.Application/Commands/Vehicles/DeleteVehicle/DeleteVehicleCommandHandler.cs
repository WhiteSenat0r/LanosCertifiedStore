using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Vehicles.DeleteVehicle;

internal sealed class DeleteVehicleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.RetrieveRepository<Vehicle>().RemoveExistingEntity(request.Id);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete a vehicle!");
    }
}