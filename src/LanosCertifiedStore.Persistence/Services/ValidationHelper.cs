using System.Linq.Expressions;
using Application.Shared.ValidationRelated;
using Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace Persistence.Services;

internal sealed class ValidationHelper(
    ApplicationDatabaseContext context) : IValidationHelper
{
    public async Task<bool> CheckAspectValueUniqueness<TMainAspect, TValue>(TValue value,
        Expression<Func<TMainAspect, bool>> equalitySelector)
        where TMainAspect : class, IIdentifiable<Guid>
    {
        var itemsCount = await context.Set<TMainAspect>().CountAsync(equalitySelector);

        return itemsCount.Equals(0);
    }

    public async Task<bool> CheckMainAspectPresence<TMainAspect>(Guid id)
        where TMainAspect : class, IIdentifiable<Guid>
    {
        return await context.Set<TMainAspect>().AnyAsync(aspect => aspect.Id == id);
    }

    public async Task<(Guid? Id, bool IsSuccess)> CheckMainAspectPresence<TMainAspect>(IEnumerable<Guid> ids)
        where TMainAspect : class, IIdentifiable<Guid>
    {
        var set = context.Set<TMainAspect>();

        foreach (var id in ids)
        {
            var existsById = await CheckMainAspectPresence<TMainAspect>(id);

            if (!existsById)
            {
                return (id, false);
            }
        }

        return (null, true);
    }

    public async Task<bool> CheckSecondaryAspectPresence<TMainAspect, TSecondaryAspect>(
        (Guid?, Guid?)? ids,
        Func<TMainAspect, Guid> mainAspectIdSelector)
        where TMainAspect : class, IIdentifiable<Guid>
        where TSecondaryAspect : class, IIdentifiable<Guid>
    {
        // if (!IsValidInputData(ids, out var mainAspectId, out var secondaryAspectId)) 
        //     return false;
        //
        // var mainAspect = await unitOfWork.RetrieveRepository<TMainAspect>().GetEntityByIdAsync(
        //     mainAspectId!.Value);
        // var secondaryAspect = await unitOfWork.RetrieveRepository<TSecondaryAspect>().GetEntityByIdAsync(
        //     secondaryAspectId!.Value);
        //
        // if (!AreExistingItems(mainAspect, secondaryAspect)) return false;
        //
        // var selectedId = mainAspectIdSelector(mainAspect!);
        //
        // return selectedId.Equals(secondaryAspectId);
        throw new NotImplementedException();
    }

    public async Task<bool> CheckSecondaryAspectPresence<TMainAspect, TSecondaryAspect>(
        (Guid?, Guid?)? ids,
        Func<TMainAspect, IEnumerable<Guid>> mainAspectIdsSelector)
        where TMainAspect : class, IIdentifiable<Guid>
        where TSecondaryAspect : class, IIdentifiable<Guid>
    {
        // if (!IsValidInputData(ids, out var mainAspectId, out var secondaryAspectId)) 
        //     return false;
        //
        // var mainAspect = await unitOfWork.RetrieveRepository<TMainAspect>().GetEntityByIdAsync(
        //     mainAspectId!.Value);
        // var secondaryAspect = await unitOfWork.RetrieveRepository<TSecondaryAspect>().GetEntityByIdAsync(
        //     secondaryAspectId!.Value);
        //
        // if (!AreExistingItems(mainAspect, secondaryAspect)) return false;
        //
        // var selectedIds = mainAspectIdsSelector(mainAspect!);
        //
        // return selectedIds.Contains(secondaryAspectId.Value);
        throw new NotImplementedException();
    }

    private bool AreExistingItems<TMainAspect, TSecondaryAspect>(
        TMainAspect? mainAspect, TSecondaryAspect? secondaryAspect)
        where TMainAspect : class, IIdentifiable<Guid>
        where TSecondaryAspect : class, IIdentifiable<Guid>
    {
        if (mainAspect is null)
        {
            return false;
        }

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

        if (IsInvalidAspectId(mainAspectId))
        {
            return false;
        }

        return !IsInvalidAspectId(secondaryAspectId);
    }

    private bool IsInvalidAspectId(Guid? id) => id is null || id.Value.Equals(Guid.Empty);
}