using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Brands.UpdateBrand;

internal sealed class UpdateBrandCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateBrandCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await unitOfWork.RetrieveRepository<VehicleBrand>().GetEntityByIdAsync(request.UpdateBrandDto.Id);

        if (brand is null)
            return Result<Unit>.Failure(Error.NotFound);

        brand.Name = request.UpdateBrandDto.UpdatedName;

        unitOfWork.RetrieveRepository<VehicleBrand>().UpdateExistingEntity(brand);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("UpdateError", "Failed to update brand"));
    }
}