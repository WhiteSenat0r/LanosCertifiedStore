using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Commands.Types.VehicleTransmissionTypeRelated.UpdateTransmissionType;

internal sealed class UpdateTransmissionTypeCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<UpdateTransmissionTypeCommand, Result<Unit>>
{
    public UpdateTransmissionTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("UpdateTransmissionTypeError", "Saving the updated body type was not successful!"),
            new Error("UpdateTransmissionTypeError", "Error occured during the body type update!")
        ];
    }

    public async Task<Result<Unit>> Handle(UpdateTransmissionTypeCommand request, CancellationToken cancellationToken)
    {
        var transmissionTypeRepository = GetRequiredRepository<VehicleTransmissionType>();
        var existingTransmissionType = await transmissionTypeRepository.GetEntityByIdAsync(request.Id);

        if (existingTransmissionType is null) return Result<Unit>.Failure(Error.NotFound);

        UpdateTransmissionType(request.UpdatedName, existingTransmissionType, transmissionTypeRepository);

        return await TrySaveChanges(cancellationToken);
    }

    private void UpdateTransmissionType(string updatedName, 
        VehicleTransmissionType existingType, IRepository<VehicleTransmissionType> bodyTypeRepository)
    {
        existingType.Name = updatedName;

        bodyTypeRepository.UpdateExistingEntityAsync(existingType);
    }
}