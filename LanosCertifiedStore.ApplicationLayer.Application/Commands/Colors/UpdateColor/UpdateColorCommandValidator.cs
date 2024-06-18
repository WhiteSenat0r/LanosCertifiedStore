using System.Text.RegularExpressions;
using Application.Commands.Colors.Shared;
using Application.Contracts.RepositoryRelated.Common;
using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Constants.VehicleRelated;
using Domain.Models.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Colors.UpdateColor;

// TODO
// internal sealed class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
// {
//     public UpdateColorCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
//     {
//         RuleFor(x => x.UpdatedName)
//             .NotEmpty()
//             .MinimumLength(VehicleColorConstants.MinimalNameLength)
//             .MaximumLength(VehicleColorConstants.MaximumNameLength)
//             .WithMessage(VehicleColorValidatorMessages.InvalidNameValue);
//
//         RuleFor(x => x.UpdatedName)
//             .MustAsync(async (name, _) => 
//                 await validationHelper.IsAspectValueUnique<VehicleColor, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleColor.Name)))
//             .WithMessage(VehicleColorValidatorMessages.AlreadyExistingNameValue);
//         
//         RuleFor(x => x.UpdatedHexValue)
//             .NotEmpty()
//             .Must(hexValue => new Regex(VehicleColorConstants.HexPattern).IsMatch(hexValue.ToUpper()))
//             .WithMessage(VehicleColorValidatorMessages.InvalidHexValue);
//     }
// }