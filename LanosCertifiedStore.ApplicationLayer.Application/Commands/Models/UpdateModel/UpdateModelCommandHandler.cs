using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Entities.VehicleRelated.Classes.TypesRelated;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Models.UpdateModel;

internal sealed class UpdateModelCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<UpdateModelCommand, Result<Unit>>
{
    public UpdateModelCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors = new[]
        {
            new Error("UpdateModelError", "Saving an updated model was not successful!"),
            new Error("UpdateModelError", "Error occured during the model update!")
        };
    }

    public async Task<Result<Unit>> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        var modelRepository = GetRequiredRepository<VehicleModel>();
        
        var updatedModelResult = await TryGetUpdatedModel(modelRepository, request.Id);
        if (!updatedModelResult.IsSuccess) return Result<Unit>.Failure(updatedModelResult.Error!);
        
        var modelUpdateResult = await UpdateModel(updatedModelResult.Value!, request);

        if (!modelUpdateResult.IsSuccess) return modelUpdateResult;
        
        await modelRepository.UpdateExistingEntityAsync(updatedModelResult.Value!);

        return await TrySaveChanges(cancellationToken);
    }

    private async Task<Result<Unit>> UpdateModel(VehicleModel model, UpdateModelCommand request)
    {
        var brandUpdateResult = await TryUpdateRelatedBrand(model, request.BrandId);
        if (!brandUpdateResult.IsSuccess) return brandUpdateResult;

        var typesUpdateResult = await TryUpdateRelatedTypes(
            GetRequiredRepository<VehicleType>(), model, request.AvailableTypesIds);
        if (!typesUpdateResult.IsSuccess) return typesUpdateResult;
        
        model.Name = request.UpdatedName;

        return Result<Unit>.Success(Unit.Value);
    }
    
    private async Task<Result<VehicleModel>> TryGetUpdatedModel(
        IRepository<VehicleModel> repository, Guid modelId)
    {
        var updatedModel = await  repository.GetEntityByIdAsync(modelId);
        
        return updatedModel is null 
            ? Result<VehicleModel>.Failure(Error.NotFound)
            : Result<VehicleModel>.Success(updatedModel);
    }
    
    private async Task<Result<Unit>> TryUpdateRelatedBrand(VehicleModel model, Guid newBrandId)
    {
        if (model.Brand.Id.Equals(newBrandId)) return Result<Unit>.Success(Unit.Value);
        
        var newBrand = await GetRequiredRepository<VehicleBrand>().GetEntityByIdAsync(newBrandId);

        if (newBrand is null) return Result<Unit>.Failure(Error.NotFound);

        model.Brand = newBrand;
        
        return Result<Unit>.Success(Unit.Value);
    }
    
    private async Task<Result<Unit>> TryUpdateRelatedTypes(
        IRepository<VehicleType> repository, VehicleModel model, IEnumerable<Guid> typeIds)
    {
        if (model.AvailableTypes.Select(x => x.Id).SequenceEqual(typeIds))
            return Result<Unit>.Success(Unit.Value);
        
        model.AvailableTypes.Clear();
        
        foreach (var typeId in typeIds)
        {
            var type = await repository.GetEntityByIdAsync(typeId);
            
            if (type is null)
                return Result<Unit>.Failure(Error.NotFound);
                    
            model.AvailableTypes.Add(type);
        }
        
        return Result<Unit>.Success(Unit.Value);
    }
}