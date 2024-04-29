using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Application.Helpers.ValidationRelated.Common.Contracts;

internal interface IValidationHelper
{
    Task<bool> IsAspectNameUnique<TMainAspect>(
        IUnitOfWork unitOfWork, string name)
        where TMainAspect : NamedVehicleAspect;
    
    Task<bool> CheckMainAspectPresence<TMainAspect>(
        IUnitOfWork unitOfWork, Guid id)
        where TMainAspect : class, IIdentifiable<Guid>;
    
    Task<bool> CheckSecondaryAspectPresence<TMainAspect, TSecondaryAspect>(
        IUnitOfWork unitOfWork,
        (Guid?, Guid?)? ids,
        Func<TMainAspect, IEnumerable<Guid>> mainAspectIdsSelector)
        where TMainAspect : class, IIdentifiable<Guid>
        where TSecondaryAspect : class, IIdentifiable<Guid>;

    Task<bool> CheckSecondaryAspectPresence<TMainAspect, TSecondaryAspect>(
        IUnitOfWork unitOfWork,
        (Guid?, Guid?)? ids,
        Func<TMainAspect, Guid> mainAspectIdSelector)
        where TMainAspect : class, IIdentifiable<Guid>
        where TSecondaryAspect : class, IIdentifiable<Guid>;
}