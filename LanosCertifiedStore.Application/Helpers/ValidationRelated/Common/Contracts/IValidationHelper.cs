namespace Application.Helpers.ValidationRelated.Common.Contracts;

// TODO
// internal interface IValidationHelper
// {
//     Task<bool> IsAspectValueUnique<TMainAspect, TValue>(
//         IUnitOfWork unitOfWork, TValue value, string aspectName)
//         where TMainAspect : NamedVehicleAspect;
//     
//     Task<bool> CheckMainAspectPresence<TMainAspect>(
//         IUnitOfWork unitOfWork, Guid id)
//         where TMainAspect : class, IIdentifiable<Guid>;
//     
//     Task<bool> CheckMainAspectPresence<TMainAspect>(
//         IUnitOfWork unitOfWork, IEnumerable<Guid> ids)
//         where TMainAspect : class, IIdentifiable<Guid>;
//     
//     Task<bool> CheckSecondaryAspectPresence<TMainAspect, TSecondaryAspect>(
//         IUnitOfWork unitOfWork,
//         (Guid?, Guid?)? ids,
//         Func<TMainAspect, IEnumerable<Guid>> mainAspectIdsSelector)
//         where TMainAspect : class, IIdentifiable<Guid>
//         where TSecondaryAspect : class, IIdentifiable<Guid>;
//
//     Task<bool> CheckSecondaryAspectPresence<TMainAspect, TSecondaryAspect>(
//         IUnitOfWork unitOfWork,
//         (Guid?, Guid?)? ids,
//         Func<TMainAspect, Guid> mainAspectIdSelector)
//         where TMainAspect : class, IIdentifiable<Guid>
//         where TSecondaryAspect : class, IIdentifiable<Guid>;
// }