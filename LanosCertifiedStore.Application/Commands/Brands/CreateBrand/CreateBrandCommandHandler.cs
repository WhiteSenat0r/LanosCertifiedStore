namespace Application.Commands.Brands.CreateBrand;

// TODO
// internal sealed class CreateBrandCommandHandler : 
//     CommandHandlerBase<Unit>, IRequestHandler<CreateBrandCommand, Result<Unit>>
// {
//     public CreateBrandCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
//     {
//         PossibleErrors =
//         [
//             new Error(
//                 VehicleBrandHandlerErrorNames.CreationError, VehicleBrandHandlerMessages.FailedSavingNewBrandProcess),
//             new Error(
//                 VehicleBrandHandlerErrorNames.CreationError, VehicleBrandHandlerMessages.FailedCreationProcess)
//         ];
//     }
//
//     public async Task<Result<Unit>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
//     {
//         var newBrand = new VehicleBrand(request.Name);
//         
//         await GetRequiredRepository<VehicleBrand>().AddNewEntityAsync(newBrand);
//
//         return await TrySaveChanges(cancellationToken);
//     }
// }