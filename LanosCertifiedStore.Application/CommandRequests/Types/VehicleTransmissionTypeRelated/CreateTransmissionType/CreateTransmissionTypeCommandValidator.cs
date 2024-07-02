namespace Application.CommandRequests.Types.VehicleTransmissionTypeRelated.CreateTransmissionType;

// TODO
// internal sealed class CreateTransmissionTypeCommandValidator : AbstractValidator<CreateTransmissionTypeCommand>
// {
//     public CreateTransmissionTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper inputValidationService)
//     {
//         RuleFor(x => x.Name)
//             .NotEmpty()
//             .MaximumLength(64)
//             .MinimumLength(2)
//             .WithMessage("Name must be greater than 2 characters and less than 64!");
//
//         RuleFor(x => x.Name)
//             .MustAsync(async (name, _) => 
//                 await inputValidationService.CheckAspectValueUniqueness<VehicleTransmissionType, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleTransmissionType.Name)))
//             .WithMessage("Transmission type with such name already exists!");
//     }
// }