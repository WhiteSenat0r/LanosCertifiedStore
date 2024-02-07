using Application.Core;
using Application.QuerySpecifications.ModelRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Models.UpdateModel;

internal sealed class UpdateModelCommandHandler(IRepository<VehicleModel> modelRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateModelCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        var existingModel = await modelRepository.GetSingleEntityBySpecificationAsync(
                new ModelByNameQuerySpecification(request.UpdateModelDto.CurrentName));

        if (existingModel is null) return null;

        existingModel.Name = request.UpdateModelDto.UpdatedName;
        
        modelRepository.UpdateExistingEntity(existingModel);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to update model!");
    }
}