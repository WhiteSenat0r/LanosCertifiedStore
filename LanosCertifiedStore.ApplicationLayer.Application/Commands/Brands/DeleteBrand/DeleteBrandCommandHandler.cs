using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Brands.DeleteBrand;

internal sealed class DeleteBrandCommandHandler(IRepository<VehicleBrand> brandRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteBrandCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetEntityByIdAsync(request.Id);

        if (brand is null)
            return Result<Unit>.Failure("Such brand doesn't exists!");

        brandRepository.RemoveExistingEntity(brand);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete brand");
    }
}