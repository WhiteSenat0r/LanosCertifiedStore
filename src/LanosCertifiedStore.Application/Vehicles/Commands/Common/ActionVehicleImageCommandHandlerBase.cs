﻿namespace LanosCertifiedStore.Application.Vehicles.Commands.Common;

// TODO
// internal abstract class ActionVehicleImageCommandHandlerBase(
//     IUnitOfWork unitOfWork) : CommandHandlerBase<Unit>(unitOfWork)
// {
//     private protected Result<Unit> GetImageCheckResult(VehicleImage? image, Vehicle vehicle)
//     {
//         if (image is null) return Result<Unit>.Failure(Error.NotFound);
//
//         if (!IsVehicleImage(vehicle, image)) return Result<Unit>.Failure(PossibleErrors[2]);
//         
//         return image.IsMainImage 
//             ? Result<Unit>.Failure(PossibleErrors[3]) 
//             : Result<Unit>.Success(Unit.Value);
//     }
//
//     private bool IsVehicleImage(Vehicle vehicle, VehicleImage image) => 
//         vehicle.Images.Select(x => x.Id).Contains(image.Id);
// }