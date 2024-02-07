using Application.Core;
using Application.QuerySpecifications.BrandRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Brands.CreateBrand;

internal sealed class CreateBrandCommandHandler(IRepository<VehicleBrand> brandRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateBrandCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var existingBrand =
            await brandRepository.GetSingleEntityBySpecificationAsync(new BrandQuerySpecification(request.Name));

        if (existingBrand is not null)
            return Result<Unit>.Failure("Model with such name already exists!");

        var brand = new VehicleBrand(request.Name);
        await brandRepository.AddNewEntityAsync(brand);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to create brand!");
    }
}