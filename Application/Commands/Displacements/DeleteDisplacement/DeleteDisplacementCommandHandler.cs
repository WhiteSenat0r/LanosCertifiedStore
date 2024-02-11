using Application.Core;
using Application.QuerySpecifications.DisplacementRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Displacements.DeleteDisplacement;

internal sealed class DeleteDisplacementCommandHandler(
    IRepository<VehicleDisplacement> displacementRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteDisplacementCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteDisplacementCommand request, CancellationToken cancellationToken)
    {
        var deletedDisplacement = await displacementRepository.GetSingleEntityBySpecificationAsync(
                new DisplacementByValueQuerySpecification(request.Value));

        if (deletedDisplacement is null)
            return Result<Unit>.Failure("Such displacement doesn't exists!");
        
        displacementRepository.RemoveExistingEntity(deletedDisplacement);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete displacement!");
    }
}