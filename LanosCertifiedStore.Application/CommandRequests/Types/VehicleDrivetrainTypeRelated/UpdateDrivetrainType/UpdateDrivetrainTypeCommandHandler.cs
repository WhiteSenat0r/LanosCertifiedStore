namespace Application.CommandRequests.Types.VehicleDrivetrainTypeRelated.UpdateDrivetrainType;

// TODO
// internal sealed class UpdateDrivetrainTypeCommandHandler : 
//     CommandHandlerBase<Unit>, IRequestHandler<UpdateDrivetrainTypeCommand, Result<Unit>>
// {
//     public UpdateDrivetrainTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
//     {
//         PossibleErrors =
//         [
//             new Error("UpdateDrivetrainTypeError", "Saving the updated engine type was not successful!"),
//             new Error("UpdateDrivetrainTypeError", "Error occured during the engine type update!")
//         ];
//     }
//
//     public async Task<Result<Unit>> Handle(UpdateDrivetrainTypeCommand request, CancellationToken cancellationToken)
//     {
//         var drivetrainTypeRepository = GetRequiredRepository<VehicleDrivetrainType>();
//         var existingDrivetrainType = await drivetrainTypeRepository.GetEntityByIdAsync(request.Id);
//
//         if (existingDrivetrainType is null) return Result<Unit>.Failure(Error.NotFound);
//
//         UpdateDrivetrainType(request.UpdatedName, existingDrivetrainType, drivetrainTypeRepository);
//
//         return await TrySaveChanges(cancellationToken);
//     }
//
//     private void UpdateDrivetrainType(string updatedName, 
//         VehicleDrivetrainType existingType, IRepository<VehicleDrivetrainType> drivetrainTypeRepository)
//     {
//         existingType.Name = updatedName;
//
//         drivetrainTypeRepository.UpdateExistingEntityAsync(existingType);
//     }
// }