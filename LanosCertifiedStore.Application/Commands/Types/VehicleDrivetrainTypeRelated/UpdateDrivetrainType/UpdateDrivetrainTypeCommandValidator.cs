namespace Application.Commands.Types.VehicleDrivetrainTypeRelated.UpdateDrivetrainType;

// TODO
// internal sealed class UpdateDrivetrainTypeCommandValidator : AbstractValidator<UpdateDrivetrainTypeCommand>
// {
//     public UpdateDrivetrainTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper inputValidationService)
//     {
//         RuleFor(x => x.UpdatedName)
//             .NotEmpty()
//             .MaximumLength(64)
//             .MinimumLength(2)
//             .WithMessage("Name must be greater than 2 characters and less than 64!");
//
//         RuleFor(x => x.UpdatedName)
//             .MustAsync(async (name, _) => 
//                 await inputValidationService.CheckAspectValueUniqueness<VehicleDrivetrainType, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleDrivetrainType.Name)))
//             .WithMessage("Drivetrain type with such name already exists!");
//     }
// }