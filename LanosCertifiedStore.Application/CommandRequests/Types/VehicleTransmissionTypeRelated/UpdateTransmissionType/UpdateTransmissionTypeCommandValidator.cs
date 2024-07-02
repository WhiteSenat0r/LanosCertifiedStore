namespace Application.CommandRequests.Types.VehicleTransmissionTypeRelated.UpdateTransmissionType;

// TODO
// internal sealed class UpdateTransmissionTypeCommandValidator : AbstractValidator<UpdateTransmissionTypeCommand>
// {
//     public UpdateTransmissionTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper inputValidationService)
//     {
//         RuleFor(x => x.UpdatedName)
//             .NotEmpty()
//             .MaximumLength(64)
//             .MinimumLength(2)
//             .WithMessage("Name must be greater than 2 characters and less than 64!");
//
//         RuleFor(x => x.UpdatedName)
//             .MustAsync(async (name, _) => 
//                 await inputValidationService.CheckAspectValueUniqueness<VehicleTransmissionType, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleTransmissionType.Name)))
//             .WithMessage("Transmission type with such name already exists!");
//     }
// }