using Domain.Contracts.Common;
using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Application.Helpers.ValidationRelated.Common.Contracts;

internal interface IValidationHelper
{
    Task<bool> IsAspectValueUnique<TMainAspect, TValue>(TValue value, string aspectName)
        where TMainAspect : NamedVehicleAspect;
    
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