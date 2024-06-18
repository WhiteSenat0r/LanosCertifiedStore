using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Commands.Types.VehicleTypeRelated.CreateType;

// TODO
// internal sealed class CreateTypeCommandHandler 
//     : CommandHandlerBase<Unit>, IRequestHandler<CreateTypeCommand, Result<Unit>>
// {
//     public CreateTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
//     {
//         PossibleErrors =
//         [
//             new Error("CreateTypeError", "Saving a new vehicle type was not successful!"),
//             new Error("CreateTypeError", "Error occured during a new vehicle type creation!")
//         ];
//     }
//
//     public async Task<Result<Unit>> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
//     {
//         var newVehicleType = new VehicleType(request.Name);
//
//         await GetRequiredRepository<VehicleType>().AddNewEntityAsync(newVehicleType);
//
//         return await TrySaveChanges(cancellationToken);
//     }
// }