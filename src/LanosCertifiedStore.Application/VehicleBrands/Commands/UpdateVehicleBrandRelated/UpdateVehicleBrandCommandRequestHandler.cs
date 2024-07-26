using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;

internal sealed class UpdateVehicleBrandCommandRequestHandler(IVehicleBrandService brandService)
    : IRequestHandler<UpdateVehicleBrandCommandRequest, Result>
{
    public async Task<Result> Handle(UpdateVehicleBrandCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            await brandService.UpdateVehicleBrand(request, cancellationToken);
            return Result.Create(Error.None);
        }
        catch (KeyNotFoundException)
        {
            return Result<Unit>.Failure(Error.NotFound(request.Id));
        }
    }
}