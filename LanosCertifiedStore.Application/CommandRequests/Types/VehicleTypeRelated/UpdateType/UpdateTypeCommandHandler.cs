namespace Application.CommandRequests.Types.VehicleTypeRelated.UpdateType;

// TODO
// internal sealed class UpdateTypeCommandHandler : 
//     CommandHandlerBase<Unit>, IRequestHandler<UpdateTypeCommand, Result<Unit>>
// {
//     public UpdateTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
//     {
//         PossibleErrors =
//         [
//             new Error("UpdateTypeError", "Saving the updated vehicle type was not successful!"),
//             new Error("UpdateTypeError", "Error occured during the vehicle type update!")
//         ];
//     }
//
//     public async Task<Result<Unit>> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
//     {
//         var typeRepository = GetRequiredRepository<VehicleType>();
//         var existingType = await typeRepository.GetEntityByIdAsync(request.Id);
//
//         if (existingType is null) return Result<Unit>.Failure(Error.NotFound);
//
//         UpdateType(request.UpdatedName, existingType, typeRepository);
//
//         return await TrySaveChanges(cancellationToken);
//     }
//
//     private void UpdateType(string updatedName, 
//         VehicleType existingType, IRepository<VehicleType> typeRepository)
//     {
//         existingType.Name = updatedName;
//
//         typeRepository.UpdateExistingEntityAsync(existingType);
//     }
// }