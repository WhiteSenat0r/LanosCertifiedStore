using Application.Core;
using Application.QuerySpecifications.BrandRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Brands.UpdateBrand;

internal sealed class UpdateBrandCommandHandler(IRepository<VehicleBrand> brandRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateBrandCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetSingleEntityBySpecificationAsync(
            new BrandQuerySpecification(request.UpdateBrandDto.BrandName));

        brand.Name = request.UpdateBrandDto.UpdatedBrandName;

        brandRepository.UpdateExistingEntity(brand);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to update brand!");
    }
}