using Application.Commands.Brands.Shared.ValidatorRelated;
using Application.Contracts.RepositoryRelated.Common;
using Application.Helpers.ValidationRelated.Common.Contracts;

namespace Application.Commands.Brands.CreateBrand;

// TODO
// internal sealed class CreateBrandCommandValidator : BrandValidatorBase<CreateBrandCommand>
// {
//     public CreateBrandCommandValidator(
//         IUnitOfWork unitOfWork,
//         IValidationHelper validationHelper) : base(unitOfWork, validationHelper)
//     {
//         GetNameLengthValidationRule(x => x.Name);
//         GetNameUniquenessValidationRule(x => x.Name);
//     }
// }