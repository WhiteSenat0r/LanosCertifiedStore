using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Brands.UpdateBrand;

internal sealed class UpdateBrandCommandHandler(IRepository<VehicleBrand> brandRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateBrandCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetEntityByIdAsync(request.UpdateBrandDto.Id);

        if (brand is null) 
            return Result<Unit>.Failure("Such brand doesn't exists!");

        brand.Name = request.UpdateBrandDto.UpdatedName;

        brandRepository.UpdateExistingEntity(brand);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to update brand!");
    }
}