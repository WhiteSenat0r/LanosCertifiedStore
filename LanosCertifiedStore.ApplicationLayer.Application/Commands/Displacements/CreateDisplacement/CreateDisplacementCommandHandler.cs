using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Displacements.CreateDisplacement;

internal sealed class CreateDisplacementCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateDisplacementCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateDisplacementCommand request, CancellationToken cancellationToken)
    {
        var vehicleDisplacement = new VehicleDisplacement(request.Value);

        await unitOfWork.RetrieveRepository<VehicleDisplacement>().AddNewEntityAsync(vehicleDisplacement);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("CreateError", "Failed to create displacement!"));
    }
}