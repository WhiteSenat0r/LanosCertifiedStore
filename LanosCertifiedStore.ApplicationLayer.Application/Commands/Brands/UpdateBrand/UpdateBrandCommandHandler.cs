using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Brands.UpdateBrand;

internal sealed class UpdateBrandCommandHandler : CommandBase, IRequestHandler<UpdateBrandCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBrandCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrorMessages = 
            ["Saving an updated brand was not successful!", "Error occured during the brand update!"];
        PossibleErrorCode = "UpdateBrandError";
    }
    
    public async Task<Result<Unit>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var updatedBrand = await _unitOfWork.RetrieveRepository<VehicleBrand>().GetEntityByIdAsync(request.Id);

        if (updatedBrand is null) return Result<Unit>.Failure(Error.NotFound);

        UpdateBrand(request.UpdatedName, updatedBrand);

        return await TrySaveChanges(cancellationToken);
    }

    private void UpdateBrand(string updatedName, VehicleBrand brand)
    {
        brand.Name = updatedName;

        _unitOfWork.RetrieveRepository<VehicleBrand>().UpdateExistingEntity(brand);
    }
}