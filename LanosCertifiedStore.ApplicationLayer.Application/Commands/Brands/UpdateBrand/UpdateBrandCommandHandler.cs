using Application.Commands.Brands.Shared;
using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Brands.UpdateBrand;

internal sealed class UpdateBrandCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<UpdateBrandCommand, Result<Unit>>
{
    public UpdateBrandCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error(
                VehicleBrandHandlerErrorNames.UpdateError, VehicleBrandHandlerMessages.FailedSavingUpdatedBrandProcess),
            new Error(
                VehicleBrandHandlerErrorNames.UpdateError, VehicleBrandHandlerMessages.FailedUpdateProcess)
        ];
    }
    
    public async Task<Result<Unit>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brandRepository = GetRequiredRepository<VehicleBrand>();
        var updatedBrand = await brandRepository.GetEntityByIdAsync(request.Id);

        if (updatedBrand is null) return Result<Unit>.Failure(Error.NotFound);

        UpdateBrand(request.UpdatedName, updatedBrand, brandRepository);

        return await TrySaveChanges(cancellationToken);
    }

    private void UpdateBrand(string updatedName, VehicleBrand brand, IRepository<VehicleBrand> repository)
    {
        brand.Name = updatedName;

        repository.UpdateExistingEntityAsync(brand);
    }
}