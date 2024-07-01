namespace Application.Commands.VehicleBrandsRelated.UpdateBrand;

// TODO
// internal sealed class UpdateBrandCommandHandler : 
//     CommandHandlerBase<Unit>, IRequestHandler<UpdateBrandCommand, Result<Unit>>
// {
//     private readonly IMapper _mapper;
//
//     public UpdateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
//     {
//         _mapper = mapper;
//         PossibleErrors =
//         [
//             new Error(
//                 VehicleBrandHandlerErrorNames.UpdateError,
//                 VehicleBrandHandlerMessages.FailedSavingUpdatedBrandProcess),
//             new Error(
//                 VehicleBrandHandlerErrorNames.UpdateError,
//                 VehicleBrandHandlerMessages.FailedUpdateProcess)
//         ];
//     }
//     
//     public async Task<Result<Unit>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
//     {
//         var brandRepository = GetRequiredRepository<VehicleBrand>();
//         var updatedBrand = await brandRepository.GetEntityByIdAsync(request.Id);
//
//         if (updatedBrand is null) return Result<Unit>.Failure(Error.NotFound);
//
//         UpdateBrand(request, updatedBrand, brandRepository);
//
//         return await TrySaveChanges(cancellationToken);
//     }
//
//     private void UpdateBrand(
//         UpdateBrandCommand updateCommand,
//         VehicleBrand brand,
//         IRepository<VehicleBrand> repository)
//     {
//         _mapper.Map(updateCommand, brand);
//
//         repository.UpdateExistingEntityAsync(brand);
//     }
// }