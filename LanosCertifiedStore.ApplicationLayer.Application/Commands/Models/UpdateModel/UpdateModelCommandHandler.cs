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
            .GetEntityByIdAsync(request.UpdateModelDto.Id);

        if (existingModel is null)
            return Result<Unit>.Failure(Error.NotFound);

        existingModel.Name = request.UpdateModelDto.UpdatedName;

        unitOfWork.RetrieveRepository<VehicleModel>().UpdateExistingEntity(existingModel);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("UpdateError", "Failed to update model!"));
    }
}