namespace Application.CommandRequests.Colors.CreateColor;

// TODO
// internal sealed class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
// {
//     public CreateColorCommandValidator(IUnitOfWork unitOfWork, IValidationHelper inputValidationService)
//     {
//         RuleFor(x => x.ColorName)
//             .NotEmpty()
//             .MinimumLength(VehicleColorConstants.MinimalNameLength)
//             .MaximumLength(VehicleColorConstants.MaximumNameLength)
//             .WithMessage(VehicleColorValidatorMessages.InvalidNameValue);
//         
//         RuleFor(x => x.HexValue)
//             .NotEmpty()
//             .Must(hexValue => new Regex(VehicleColorConstants.HexPattern).IsMatch(hexValue.ToUpper()))
//             .WithMessage(VehicleColorValidatorMessages.InvalidHexValue);
//
//         RuleFor(x => x.ColorName)
//             .MustAsync(async (name, _) => 
//                 await inputValidationService.CheckAspectValueUniqueness<VehicleColor, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleColor.Name)))
//             .WithMessage(VehicleColorValidatorMessages.AlreadyExistingNameValue);
//     }
// }