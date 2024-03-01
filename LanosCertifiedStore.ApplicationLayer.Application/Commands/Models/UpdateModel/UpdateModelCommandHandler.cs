using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Models.UpdateModel;

internal sealed class UpdateModelCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<UpdateModelCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateModelCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrors = new[]
        {
            new Error("UpdateModelError", "Saving an updated model was not successful!"),
            new Error("UpdateModelError", "Error occured during the model update!")
        };
    }

    public async Task<Result<Unit>> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        // TODO Fix
        var modelRepository = _unitOfWork.RetrieveRepository<VehicleModel>();

        var modelUpdateResult = await UpdateModel(modelRepository, request);
        
        return modelUpdateResult.IsSuccess 
            ? await TrySaveChanges(cancellationToken)
            : modelUpdateResult;
    }

    private async Task<Result<Unit>> UpdateModel(IRepository<VehicleModel> repository, UpdateModelCommand request)
    {
        var updatedModelResult = await TryGetUpdatedModel(repository, request.Id);
        if (!updatedModelResult.IsSuccess) return Result<Unit>.Failure(updatedModelResult.Error!);
        
        var brandUpdateResult = await TryUpdateRelatedBrand(updatedModelResult.Value!, request.BrandId);
        if (!brandUpdateResult.IsSuccess) return brandUpdateResult;

        var typesUpdateResult = await TryUpdateRelatedTypes(
            _unitOfWork.RetrieveRepository<VehicleType>(), updatedModelResult.Value!, request.AvailableTypesIds);
        if (!typesUpdateResult.IsSuccess) return typesUpdateResult;
        
        updatedModelResult.Value!.Name = request.UpdatedName;

        repository.UpdateExistingEntity(updatedModelResult.Value);

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
        
        var newBrand = await _unitOfWork.RetrieveRepository<VehicleBrand>().GetEntityByIdAsync(newBrandId);

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