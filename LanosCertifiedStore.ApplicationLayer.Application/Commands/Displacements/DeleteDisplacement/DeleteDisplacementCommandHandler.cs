using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Displacements.DeleteDisplacement;

internal sealed class DeleteDisplacementCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteDisplacementCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteDisplacementCommand request, CancellationToken cancellationToken)
    {

        await unitOfWork.RetrieveRepository<VehicleDisplacement>().RemoveExistingEntity(request.Id);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete displacement!");
    }
}