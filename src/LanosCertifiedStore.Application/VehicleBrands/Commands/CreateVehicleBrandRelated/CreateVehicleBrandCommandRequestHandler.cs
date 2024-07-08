using Application.Shared.ResultRelated;
using MediatR;

namespace Application.VehicleBrands.Commands.CreateVehicleBrandRelated;

internal sealed class CreateVehicleBrandCommandHandler(IVehicleBrandService vehicleBrandService) : 
    IRequestHandler<CreateVehicleBrandCommandRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        CreateVehicleBrandCommandRequest request,
        CancellationToken cancellationToken)
    {
        var createdBrandId = await vehicleBrandService.AddNewVehicleBrand(request, cancellationToken);

        return Result<Guid>.Success(createdBrandId);
    }
}