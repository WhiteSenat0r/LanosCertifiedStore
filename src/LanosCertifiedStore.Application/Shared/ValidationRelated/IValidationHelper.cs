using System.Linq.Expressions;
using LanosCertifiedStore.Domain.Contracts.Common;

namespace LanosCertifiedStore.Application.Shared.ValidationRelated;

public interface IValidationHelper
{
    Task<bool> CheckAspectValueUniqueness<TMainAspect, TValue>(TValue value,
        Expression<Func<TMainAspect, bool>> equalitySelector)
        where TMainAspect : class, IIdentifiable<Guid>;
    
    Task<bool> CheckMainAspectPresence<TMainAspect>(Guid id)
        where TMainAspect : class, IIdentifiable<Guid>;
    
    Task<(Guid? Id, bool IsSuccess)> CheckMainAspectPresence<TMainAspect>(IEnumerable<Guid> ids)
        where TMainAspect : class, IIdentifiable<Guid>;
}