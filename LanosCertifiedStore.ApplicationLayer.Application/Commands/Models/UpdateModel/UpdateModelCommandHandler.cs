using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Models.UpdateModel;

internal sealed class UpdateModelCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateModelCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        var existingModel = await unitOfWork.RetrieveRepository<VehicleModel>()
            .GetEntityByIdAsync(request.Id);

        if (existingModel is null)
            return Result<Unit>.Failure(Error.NotFound);

        if (!existingModel.Brand.Id.Equals(request.BrandId))
        {
            var brand = await unitOfWork.RetrieveRepository<VehicleBrand>().GetEntityByIdAsync(request.BrandId);

            if (brand is null)
                return Result<Unit>.Failure(Error.NotFound);

            existingModel.Brand = brand;
        }
       
        if (!existingModel.AvailableTypes.Select(x => x.Id).Equals(request.AvailableTypesIds))
        {
            existingModel.AvailableTypes.Clear();

            foreach (var typeId in request.AvailableTypesIds)
            {
                var type = await unitOfWork.RetrieveRepository<VehicleType>().GetEntityByIdAsync(typeId);
                if (type is null)
                    return Result<Unit>.Failure(Error.NotFound);
                    
                existingModel.AvailableTypes.Add(type);
            }
        }

        existingModel.Name = request.UpdatedName;

        unitOfWork.RetrieveRepository<VehicleModel>().UpdateExistingEntity(existingModel);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("UpdateError", "Failed to update model!"));
    }
}