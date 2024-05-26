using Application.Commands.Common;
using Application.Commands.Types.VehicleTypesRelated.UpdateType;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleBodyTypesRelated.UpdateBodyType;

internal sealed class UpdateBodyTypeCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<UpdateTypeCommand, Result<Unit>>
{
    public UpdateBodyTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("UpdateBodyTypeError", "Saving the updated body type was not successful!"),
            new Error("UpdateBodyTypeError", "Error occured during the body type update!")
        ];
    }

    public async Task<Result<Unit>> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
    {
        var bodyTypeRepository = GetRequiredRepository<VehicleBodyType>();
        var existingBodyType = await bodyTypeRepository.GetEntityByIdAsync(request.Id);

        if (existingBodyType is null) return Result<Unit>.Failure(Error.NotFound);

        UpdateBodyType(request.UpdatedName, existingBodyType, bodyTypeRepository);

        return await TrySaveChanges(cancellationToken);
    }

    private void UpdateBodyType(string updatedName, 
        VehicleBodyType existingType, IRepository<VehicleBodyType> bodyTypeRepository)
    {
        existingType.Name = updatedName;

        bodyTypeRepository.UpdateExistingEntityAsync(existingType);
    }
}