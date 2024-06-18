namespace Application.Commands.Models.UpdateModel;

// TODO
// internal sealed class UpdateModelCommandHandler : 
//     CommandHandlerBase<Unit>, IRequestHandler<UpdateModelCommand, Result<Unit>>
// {
//     public UpdateModelCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
//     {
//         PossibleErrors =
//         [
//             new Error("UpdateModelError", "Saving an updated model was not successful!"),
//             new Error("UpdateModelError", "Error occured during the model update!")
//         ];
//     }
//
//     public async Task<Result<Unit>> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
//     {
//         var modelRepository = GetRequiredRepository<VehicleModel>();
//         
//         var updatedModelResult = await TryGetUpdatedModel(modelRepository, request.Id);
//         if (!updatedModelResult.IsSuccess) return Result<Unit>.Failure(updatedModelResult.Error!);
//         
//         var modelUpdateResult = await UpdateModel(updatedModelResult.Value!, request);
//
//         if (!modelUpdateResult.IsSuccess) return modelUpdateResult;
//         
//         await modelRepository.UpdateExistingEntityAsync(updatedModelResult.Value!);
//
//         return await TrySaveChanges(cancellationToken);
//     }
//
//     private async Task<Result<Unit>> UpdateModel(VehicleModel model, UpdateModelCommand request)
//     {
//         var updateResults = await GetUpdateResults(model, request);
//
//         foreach (var result in updateResults.Where(result => !result.IsSuccess))
//             return result;
//         
//         model.Name = request.Name;
//         model.MinimalProductionYear = request.MinimalProductionYear;
//         model.MaximumProductionYear = request.MaximumProductionYear;
//
//         return Result<Unit>.Success(Unit.Value);
//     }
//
//     private async Task<List<Result<Unit>>> GetUpdateResults(VehicleModel model, UpdateModelCommand request)
//     {
//         var aspectUpdater = new ModelAspectUpdater();
//         
//         return
//         [
//             await aspectUpdater.GetAspectUpdateResult(
//                 model, request, GetRequiredRepository<VehicleBrand>, true),
//
//             await aspectUpdater.GetAspectUpdateResult(
//                 model, request, GetRequiredRepository<VehicleType>, true),
//
//             await aspectUpdater.GetAspectUpdateResult(
//                 model, request, GetRequiredRepository<VehicleBodyType>, false),
//
//             await aspectUpdater.GetAspectUpdateResult(
//                 model, request, GetRequiredRepository<VehicleTransmissionType>, false),
//
//             await aspectUpdater.GetAspectUpdateResult(
//                 model, request, GetRequiredRepository<VehicleDrivetrainType>, false),
//
//             await aspectUpdater.GetAspectUpdateResult(
//                 model, request, GetRequiredRepository<VehicleEngineType>, false)
//         ];
//     }
//
//     private async Task<Result<VehicleModel>> TryGetUpdatedModel(
//         IRepository<VehicleModel> repository, Guid modelId)
//     {
//         var updatedModel = await  repository.GetEntityByIdAsync(modelId);
//         
//         return updatedModel is null 
//             ? Result<VehicleModel>.Failure(Error.NotFound)
//             : Result<VehicleModel>.Success(updatedModel);
//     }
// }