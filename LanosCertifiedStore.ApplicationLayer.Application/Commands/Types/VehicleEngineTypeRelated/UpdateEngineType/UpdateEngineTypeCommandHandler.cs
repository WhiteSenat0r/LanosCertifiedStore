using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Commands.Types.VehicleEngineTypeRelated.UpdateEngineType;

internal sealed class UpdateEngineTypeCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<UpdateEngineTypeCommand, Result<Unit>>
{
    public UpdateEngineTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("UpdateEngineTypeError", "Saving the updated engine type was not successful!"),
            new Error("UpdateEngineTypeError", "Error occured during the engine type update!")
        ];
    }

    public async Task<Result<Unit>> Handle(UpdateEngineTypeCommand request, CancellationToken cancellationToken)
    {
        var engineTypeRepository = GetRequiredRepository<VehicleEngineType>();
        var existingEngineType = await engineTypeRepository.GetEntityByIdAsync(request.Id);

        if (existingEngineType is null) return Result<Unit>.Failure(Error.NotFound);

        UpdateEngineType(request.UpdatedName, existingEngineType, engineTypeRepository);

        return await TrySaveChanges(cancellationToken);
    }

    private void UpdateEngineType(string updatedName, 
        VehicleEngineType existingType, IRepository<VehicleEngineType> engineTypeRepository)
    {
        existingType.Name = updatedName;

        engineTypeRepository.UpdateExistingEntityAsync(existingType);
    }
}