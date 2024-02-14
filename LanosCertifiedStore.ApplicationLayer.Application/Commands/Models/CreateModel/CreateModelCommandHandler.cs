using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Models.CreateModel;

internal sealed class CreateModelCommandHandler(
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateModelCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        var vehicleBrand = await unitOfWork.RetrieveRepository<VehicleBrand>().GetEntityByIdAsync(request.BrandId);
        
        if (vehicleBrand is null)
            return Result<Unit>.Failure("Such brand doesn't exists!");
        
        var vehicleModel = new VehicleModel(vehicleBrand, request.Name);
        
        await unitOfWork.RetrieveRepository<VehicleModel>().AddNewEntityAsync(vehicleModel);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to create model!");
    }
}