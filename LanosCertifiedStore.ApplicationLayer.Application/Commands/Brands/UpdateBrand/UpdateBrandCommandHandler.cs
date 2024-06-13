using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Brands.UpdateBrand;

internal sealed class UpdateBrandCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<UpdateBrandCommand, Result<Unit>>
{
    public UpdateBrandCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("UpdateBrandError", "Saving an updated brand was not successful!"),
            new Error("UpdateBrandError", "Error occured during the brand update!")
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