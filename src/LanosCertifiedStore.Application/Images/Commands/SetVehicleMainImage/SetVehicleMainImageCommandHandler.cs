namespace Application.Images.Commands.SetVehicleMainImage;

// TODO
// internal sealed class SetVehicleMainImageCommandHandler
//     : ActionVehicleImageCommandHandlerBase, IRequestHandler<SetVehicleMainImageCommand, Result<Unit>>
// {
//     public SetVehicleMainImageCommandHandler(IUnitOfWork unitOfWork)
//         : base(unitOfWork)
//     {
//         PossibleErrors =
//         [
//             new Error("SetVehicleMainImageError", "Vehicle image update was not successful!"),
//             new Error("SetVehicleMainImageError", "Error occured during the vehicle image update!"),
//             new Error("SetVehicleMainImageError", "This image does not belong to this vehicle!"),
//             new Error("SetVehicleMainImageError", "Vehicle's image can't be updated!"),
//             new Error("SetVehicleMainImageError", "Failed to update vehicle's image from the cloud!")
//         ];
//     }
//     
//     public async Task<Result<Unit>> Handle(SetVehicleMainImageCommand request, CancellationToken cancellationToken)
//     {
//         var imageRepository = GetRequiredRepository<VehicleImage>();
//
//         var vehicle = await GetRequiredRepository<Vehicle>().GetEntityByIdAsync(request.VehicleId);
//
//         if (vehicle is null) return Result<Unit>.Failure(Error.NotFound);
//
//         var image = await imageRepository.GetEntityByIdAsync(request.ImageId);
//         
//         var imageCheckResult = GetImageCheckResult(image, vehicle);
//
//         if (!imageCheckResult.IsSuccess) return imageCheckResult;
//
//         var mainImage = await imageRepository.GetEntityByIdAsync(
//             vehicle.Images.Single(x => x.IsMainImage).Id);
//         
//         await SetNewMainImage(mainImage, vehicle, imageRepository, image!);
//
//         return await TrySaveChanges(cancellationToken);
//     }
//
//     private async Task SetNewMainImage(
//         VehicleImage? mainImage, 
//         Vehicle vehicle, 
//         IRepository<VehicleImage> imageRepository,
//         VehicleImage image)
//     {
//         mainImage!.Vehicle = vehicle;
//         mainImage.IsMainImage = false;
//         
//         await imageRepository.UpdateExistingEntityAsync(mainImage);
//
//         image.Vehicle = vehicle;
//         image.IsMainImage = true;
//         
//         await imageRepository.UpdateExistingEntityAsync(image);
//     }
// }