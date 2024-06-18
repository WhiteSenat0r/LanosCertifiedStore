using System.Linq.Expressions;
using Application.Commands.Brands.Shared.MessageRelated;
using Application.Contracts.RepositoryRelated.Common;
using Application.Helpers.ValidationRelated.Common.Contracts;
using Application.Shared;
using Domain.Constants.VehicleRelated;
using Domain.Models.VehicleRelated.Classes;
using FluentValidation;
using MediatR;

namespace Application.Commands.Brands.Shared.ValidatorRelated;

// TODO
// internal abstract class BrandValidatorBase<TCommand>(
//     IUnitOfWork unitOfWork,
//     IValidationHelper validationHelper) : AbstractValidator<TCommand>
//     where TCommand : IRequest<Result<Unit>>
// {
//     private protected void GetNameLengthValidationRule(Expression<Func<TCommand, string>> expression)
//     {
//         RuleFor(expression)
//             .NotEmpty()
//             .MinimumLength(VehicleBrandConstants.MinimalNameLength)
//             .MaximumLength(VehicleBrandConstants.MaximumNameLength)
//             .WithMessage(VehicleBrandValidatorMessages.InvalidNameValue);
//     }
//     
//     private protected void GetNameUniquenessValidationRule(Expression<Func<TCommand, string>> expression)
//     {
//         RuleFor(expression)
//             .MustAsync(async (name, _) => 
//                 await validationHelper.IsAspectValueUnique<VehicleBrand, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleBrand.Name)))
//             .WithMessage(VehicleBrandValidatorMessages.AlreadyExistingNameValue);
//     }
// }