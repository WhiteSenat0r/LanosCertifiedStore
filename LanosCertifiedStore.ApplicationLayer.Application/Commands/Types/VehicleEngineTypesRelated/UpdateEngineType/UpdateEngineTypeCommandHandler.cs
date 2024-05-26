using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleEngineTypesRelated.UpdateEngineType;

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
        VehicleEngineType existingType, IRepository<VehicleEngineType> bodyTypeRepository)
    {
        existingType.Name = updatedName;

        bodyTypeRepository.UpdateExistingEntityAsync(existingType);
    }
}