using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Application.Helpers.ValidationRelated;

internal sealed class ValidationHelper : IValidationHelper
{
    private const string PropertyName = "Name";

    public async Task<bool> IsAspectNameUnique<TMainAspect>(IUnitOfWork unitOfWork, string name)
        where TMainAspect : NamedVehicleAspect
    {
        var items = await unitOfWork.RetrieveRepository<TMainAspect>().GetAllEntitiesAsync();
        
        var nameProperty = typeof(TMainAspect).GetProperty(PropertyName)!;

        return items.All(x =>
            !string.Equals((string?)nameProperty.GetValue(x), name, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<bool> CheckMainAspectPresence<TMainAspect>(IUnitOfWork unitOfWork, Guid id)
        where TMainAspect : class, IIdentifiable<Guid>
    {
        var mainAspect = await unitOfWork.RetrieveRepository<TMainAspect>().GetEntityByIdAsync(id);

        return mainAspect is not null;
    }
    
    public async Task<bool> CheckSecondaryAspectPresence<TMainAspect, TSecondaryAspect>(
        IUnitOfWork unitOfWork,
        (Guid?, Guid?)? ids,
        Func<TMainAspect, Guid> mainAspectIdSelector)
        where TMainAspect : class, IIdentifiable<Guid>
        where TSecondaryAspect : class, IIdentifiable<Guid>
    {
        if (!IsValidInputData(ids, out var mainAspectId, out var secondaryAspectId)) 
            return false;

        var mainAspect = await unitOfWork.RetrieveRepository<TMainAspect>().GetEntityByIdAsync(
            mainAspectId!.Value);
        var secondaryAspect = await unitOfWork.RetrieveRepository<TSecondaryAspect>().GetEntityByIdAsync(
            secondaryAspectId!.Value);

        if (!AreExistingItems(mainAspect, secondaryAspect)) return false;

        var selectedId = mainAspectIdSelector(mainAspect!);
        
        return selectedId.Equals(secondaryAspectId);
    }

    public async Task<bool> CheckSecondaryAspectPresence<TMainAspect, TSecondaryAspect>(
        IUnitOfWork unitOfWork,
        (Guid?, Guid?)? ids,
        Func<TMainAspect, IEnumerable<Guid>> mainAspectIdsSelector)
        where TMainAspect : class, IIdentifiable<Guid>
        where TSecondaryAspect : class, IIdentifiable<Guid>
    {
        if (!IsValidInputData(ids, out var mainAspectId, out var secondaryAspectId)) 
            return false;

        var mainAspect = await unitOfWork.RetrieveRepository<TMainAspect>().GetEntityByIdAsync(
            mainAspectId!.Value);
        var secondaryAspect = await unitOfWork.RetrieveRepository<TSecondaryAspect>().GetEntityByIdAsync(
            secondaryAspectId!.Value);

        if (!AreExistingItems(mainAspect, secondaryAspect)) return false;
        
        var selectedIds = mainAspectIdsSelector(mainAspect!);
        
        return selectedIds.Contains(secondaryAspectId.Value);
    }

    private bool AreExistingItems<TMainAspect, TSecondaryAspect>(
        TMainAspect? mainAspect, TSecondaryAspect? secondaryAspect)
        where TMainAspect : class, IIdentifiable<Guid> 
        where TSecondaryAspect : class, IIdentifiable<Guid>
    {
        if (mainAspect is null) return false;
        
        return secondaryAspect is not null;
    }

    private bool IsValidInputData((Guid?, Guid?)? ids, out Guid? mainAspectId, out Guid? secondaryAspectId)
    {
        if (ids is null)
        {
            mainAspectId = null;
            secondaryAspectId = null;
            return false;
        }

        mainAspectId = ids.Value.Item1;
        secondaryAspectId = ids.Value.Item2;
        
        if (IsInvalidAspectId(mainAspectId)) return false;
        
        return !IsInvalidAspectId(secondaryAspectId);
    }

    private bool IsInvalidAspectId(Guid? id) => id is null || id.Value.Equals(Guid.Empty);
}