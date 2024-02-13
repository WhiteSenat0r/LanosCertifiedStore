using Application.Core;
using Application.QuerySpecifications.TypeRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Types.CreateType;

internal sealed class CreateTypeCommandHandler(IRepository<VehicleType> typeRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateTypeCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
    {
        var existingType = await typeRepository.GetSingleEntityBySpecificationAsync(
                new TypeByNameQuerySpecification(request.Name));

        if (existingType is not null)
            return Result<Unit>.Failure("Type with such name already exists!");

        var vehicleType = new VehicleType(request.Name);
        await typeRepository.AddNewEntityAsync(vehicleType);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to create type!");
    }
}