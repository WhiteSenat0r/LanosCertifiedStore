namespace Application.CommandRequests.Colors.UpdateColor;

// TODO
// internal sealed class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
// {
//     public UpdateColorCommandValidator(IUnitOfWork unitOfWork, IValidationHelper inputValidationService)
//     {
//         RuleFor(x => x.UpdatedName)
//             .NotEmpty()
//             .MinimumLength(VehicleColorConstants.MinimalNameLength)
//             .MaximumLength(VehicleColorConstants.MaximumNameLength)
//             .WithMessage(VehicleColorValidatorMessages.InvalidNameValue);
//
//         RuleFor(x => x.UpdatedName)
//             .MustAsync(async (name, _) => 
//                 await inputValidationService.CheckAspectValueUniqueness<VehicleColor, string>(
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