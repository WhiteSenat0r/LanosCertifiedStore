using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Models.UpdateModel.Common.Classes;

internal sealed class ModelAspectUpdater
{
    internal async Task<Result<Unit>> GetAspectUpdateResult<TAspect>(
        VehicleModel model,
        UpdateModelCommand request,
        Func<IRepository<TAspect>> repository,
        bool isSingleAspect)
        where TAspect : class, IIdentifiable<Guid> =>
        isSingleAspect
            ? await GetSingleAspectResult(model, request, repository)
            : await GetMultipleAspectResult(model, request, repository);

    private async Task<Result<Unit>> GetMultipleAspectResult<TAspect>(
        VehicleModel model, UpdateModelCommand request, Func<IRepository<TAspect>> repository)
        where TAspect : class, IIdentifiable<Guid>
    {
        var multipleAspectMapping = ModelUpdateMappings<TAspect>.MultipleAspectMappings[typeof(TAspect)];
        var multipleAspectActionMapping = ModelUpdateMappings<TAspect>.MultipleAspectActionMappings[typeof(TAspect)];
            
        return await TryUpdateRelatedAspects(
            model, multipleAspectMapping, multipleAspectActionMapping,
            repository, GetMultipleAspectIds<TAspect>(request));
    }

    private async Task<Result<Unit>> GetSingleAspectResult<TAspect>(
        VehicleModel model, UpdateModelCommand request, Func<IRepository<TAspect>> repository)
        where TAspect : class, IIdentifiable<Guid>
    {
        var singleAspectMapping = ModelUpdateMappings<TAspect>.SingleAspectMappings[typeof(TAspect)];
        var singleAspectActionMapping = ModelUpdateMappings<TAspect>.SingleAspectActionMappings[typeof(TAspect)];
            
        return await TryUpdateRelatedSingleAspect(
            model, singleAspectMapping, singleAspectActionMapping,
            repository, GetSingleAspectId<TAspect>(request));
    }

    private Guid GetSingleAspectId<TAspect>(UpdateModelCommand request)
        where TAspect : class
    {
        if (typeof(TAspect) == typeof(VehicleBrand))
            return request.BrandId;
        
        if (typeof(TAspect) == typeof(VehicleType))
            return request.TypeId;

        throw new InvalidOperationException(
            "ID can't be extracted due to the absence of the valid aspect type!");
    }
    
    private IEnumerable<Guid> GetMultipleAspectIds<TAspect>(UpdateModelCommand request)
        where TAspect : class
    {
        if (typeof(TAspect) == typeof(VehicleBodyType))
            return request.AvailableBodyTypeIds;
        
        if (typeof(TAspect) == typeof(VehicleEngineType))
            return request.AvailableEngineTypeIds;
        
        if (typeof(TAspect) == typeof(VehicleTransmissionType))
            return request.AvailableTransmissionTypeIds;
        
        if (typeof(TAspect) == typeof(VehicleDrivetrainType))
            return request.AvailableDrivetrainTypeIds;

        throw new InvalidOperationException(
            "IDs can't be extracted due to the absence of the valid aspect type!");
    }

    private async Task<Result<Unit>> TryUpdateRelatedAspects<TAspect>(
        VehicleModel model,
        Func<VehicleModel, ICollection<TAspect>> aspectSelector,
        Action<VehicleModel, ICollection<TAspect>> updateAction,
        Func<IRepository<TAspect>> repository,
        IEnumerable<Guid> newAspectIds)
        where TAspect : class, IIdentifiable<Guid>
    {
        if (aspectSelector(model).All(a => newAspectIds.Contains(a.Id)))
            return Result<Unit>.Success(Unit.Value);

        var newAspects = new List<TAspect>();

        foreach (var newAspectId in newAspectIds)
        {
            var newAspect = await repository().GetEntityByIdAsync(newAspectId);

            if (newAspect is null) return Result<Unit>.Failure(Error.NotFound);
            
            newAspects.Add(newAspect);
        }

        updateAction(model, newAspects);
        
        return Result<Unit>.Success(Unit.Value);
    }
    
    private async Task<Result<Unit>> TryUpdateRelatedSingleAspect<TAspect>(
        VehicleModel model,
        Func<VehicleModel, TAspect> aspectSelector,
        Action<VehicleModel, TAspect> updateAction,
        Func<IRepository<TAspect>> repository,
        Guid newAspectId)
        where TAspect : class, IIdentifiable<Guid>
    {
        if (aspectSelector(model).Id.Equals(newAspectId)) return Result<Unit>.Success(Unit.Value);
        
        var newAspect = await repository().GetEntityByIdAsync(newAspectId);

        if (newAspect is null) return Result<Unit>.Failure(Error.NotFound);

        updateAction(model, newAspect);
        
        return Result<Unit>.Success(Unit.Value);
    }
}