using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Brands.CreateBrand;

internal sealed class CreateBrandCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateBrandCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = new VehicleBrand(request.Name);
        await unitOfWork.RetrieveRepository<VehicleBrand>().AddNewEntityAsync(brand);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to create brand!");
    }
}