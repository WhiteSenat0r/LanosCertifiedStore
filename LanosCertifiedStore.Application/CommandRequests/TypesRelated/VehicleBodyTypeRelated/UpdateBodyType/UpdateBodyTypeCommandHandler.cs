namespace Application.CommandRequests.TypesRelated.VehicleBodyTypeRelated.UpdateBodyType;

// TODO
// internal sealed class UpdateBodyTypeCommandHandler : 
//     CommandHandlerBase<Unit>, IRequestHandler<UpdateBodyTypeCommand, Result<Unit>>
// {
//     public UpdateBodyTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
//     {
//         PossibleErrors =
//         [
//             new Error("UpdateBodyTypeError", "Saving the updated body type was not successful!"),
//             new Error("UpdateBodyTypeError", "Error occured during the body type update!")
//         ];
//     }
//
//     public async Task<Result<Unit>> Handle(UpdateBodyTypeCommand request, CancellationToken cancellationToken)
//     {
//         var bodyTypeRepository = GetRequiredRepository<VehicleBodyType>();
//         var existingBodyType = await bodyTypeRepository.GetEntityByIdAsync(request.Id);
//
//         if (existingBodyType is null) return Result<Unit>.Failure(Error.NotFound);
//
//         UpdateBodyType(request.UpdatedName, existingBodyType, bodyTypeRepository);
//
//         return await TrySaveChanges(cancellationToken);
//     }
//
//     private void UpdateBodyType(string updatedName, 
//         VehicleBodyType existingType, IRepository<VehicleBodyType> bodyTypeRepository)
//     {
//         existingType.Name = updatedName;
//
//         bodyTypeRepository.UpdateExistingEntityAsync(existingType);
//     }
// }