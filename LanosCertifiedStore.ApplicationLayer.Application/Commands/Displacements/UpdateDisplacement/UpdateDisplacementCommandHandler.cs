using Application.Core;
using Application.QuerySpecifications.DisplacementRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Displacements.UpdateDisplacement;

internal sealed class UpdateDisplacementCommandHandler(
    IRepository<VehicleDisplacement> displacementRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateDisplacementCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateDisplacementCommand request, CancellationToken cancellationToken)
    {
        var existingDisplacement = await displacementRepository.GetSingleEntityBySpecificationAsync(
                new DisplacementByValueQuerySpecification(request.UpdateDisplacementDto.CurrentValue));

        if (existingDisplacement is null) 
            return Result<Unit>.Failure("Such displacement doesn't exists!");
        
        var updatedValueDisplacement = await displacementRepository.GetSingleEntityBySpecificationAsync(
            new DisplacementByValueQuerySpecification(request.UpdateDisplacementDto.UpdatedValue));

        if (updatedValueDisplacement is not null)
            return Result<Unit>.Failure("Displacement with such value already exists!");

        existingDisplacement.Value = request.UpdateDisplacementDto.UpdatedValue;
        
        displacementRepository.UpdateExistingEntity(existingDisplacement);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to update displacement!");
    }
}