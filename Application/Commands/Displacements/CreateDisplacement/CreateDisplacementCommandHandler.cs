using Application.Core;
using Application.QuerySpecifications.DisplacementRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Displacements.CreateDisplacement;

internal sealed class CreateDisplacementCommandHandler(
    IRepository<VehicleDisplacement> displacementRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateDisplacementCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateDisplacementCommand request, CancellationToken cancellationToken)
    {
        var existingDisplacement = await displacementRepository.GetSingleEntityBySpecificationAsync(
                new DisplacementByValueQuerySpecification(request.Value));

        if (existingDisplacement is not null)
            return Result<Unit>.Failure("Displacement with such value already exists!");

        var vehicleDisplacement = new VehicleDisplacement(request.Value);
        await displacementRepository.AddNewEntityAsync(vehicleDisplacement);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to create displacement!");
    }
}