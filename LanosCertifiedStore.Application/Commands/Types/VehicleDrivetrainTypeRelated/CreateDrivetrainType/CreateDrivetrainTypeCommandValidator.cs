namespace Application.Commands.Types.VehicleDrivetrainTypeRelated.CreateDrivetrainType;

// TODO
// internal sealed class CreateDrivetrainTypeCommandValidator : AbstractValidator<CreateDrivetrainTypeCommand>
// {
//     public CreateDrivetrainTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper inputValidationService)
//     {
//         RuleFor(x => x.Name)
//             .NotEmpty()
//             .MaximumLength(64)
//             .MinimumLength(2)
//             .WithMessage("Name must be greater than 2 characters and less than 64!");
//
//         RuleFor(x => x.Name)
//             .MustAsync(async (name, _) => 
//                 await inputValidationService.CheckAspectValueUniqueness<VehicleDrivetrainType, string>(
//                         unitOfWork,
//                         name,
//                         nameof(VehicleDrivetrainType.Name)))
//             .WithMessage("Drivetrain type with such name already exists!");
//     }
// }