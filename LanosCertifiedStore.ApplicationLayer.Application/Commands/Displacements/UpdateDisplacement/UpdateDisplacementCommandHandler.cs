using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Displacements.UpdateDisplacement;

internal sealed class UpdateDisplacementCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateDisplacementCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateDisplacementCommand request, CancellationToken cancellationToken)
    {
        var existingDisplacement = await unitOfWork.RetrieveRepository<VehicleDisplacement>()
            .GetEntityByIdAsync(request.UpdateDisplacementDto.Id);

        if (existingDisplacement is null)
            return Result<Unit>.Failure(Error.NotFound);

        existingDisplacement.Value = request.UpdateDisplacementDto.UpdatedValue;

        unitOfWork.RetrieveRepository<VehicleDisplacement>().UpdateExistingEntity(existingDisplacement);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("DeleteError", "Failed to update displacement!"));
    }
}