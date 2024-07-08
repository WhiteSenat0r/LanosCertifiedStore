using System.Linq.Expressions;
using Domain.Contracts.Common;

namespace Application.Shared.ValidationRelated;

public interface IValidationHelper
{
    Task<bool> CheckAspectValueUniqueness<TMainAspect, TValue>(TValue value,
        Expression<Func<TMainAspect, bool>> equalitySelector)
        where TMainAspect : class, IIdentifiable<Guid>;
    
    Task<bool> CheckMainAspectPresence<TMainAspect>(Guid id)
        where TMainAspect : class, IIdentifiable<Guid>;
    
    Task<bool> CheckMainAspectPresence<TMainAspect>(IEnumerable<Guid> ids)
        where TMainAspect : class, IIdentifiable<Guid>;
    
    Task<bool> CheckSecondaryAspectPresence<TMainAspect, TSecondaryAspect>(
        (Guid?, Guid?)? ids,
        Func<TMainAspect, IEnumerable<Guid>> mainAspectIdsSelector)
        where TMainAspect : class, IIdentifiable<Guid>
        where TSecondaryAspect : class, IIdentifiable<Guid>;

    Task<bool> CheckSecondaryAspectPresence<TMainAspect, TSecondaryAspect>(
        (Guid?, Guid?)? ids,
        Func<TMainAspect, Guid> mainAspectIdSelector)
        where TMainAspect : class, IIdentifiable<Guid>
        where TSecondaryAspect : class, IIdentifiable<Guid>;
}