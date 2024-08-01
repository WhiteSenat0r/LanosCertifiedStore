using System.Linq.Expressions;
using LanosCertifiedStore.Application.Shared.ValidationRelated;
using LanosCertifiedStore.Domain.Contracts.Common;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Services;

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
}