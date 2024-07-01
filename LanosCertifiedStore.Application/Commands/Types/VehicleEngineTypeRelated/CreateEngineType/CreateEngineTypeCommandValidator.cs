namespace Application.Commands.Types.VehicleEngineTypeRelated.CreateEngineType;

// TODO
// internal sealed class CreateEngineTypeCommandValidator : AbstractValidator<CreateEngineTypeCommand>
// {
//     public CreateEngineTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper inputValidationService)
//     {
//         RuleFor(x => x.Name)
//             .NotEmpty()
//             .MaximumLength(64)
//             .MinimumLength(2)
//             .WithMessage("Name must be greater than 2 characters and less than 64!");
//
//         RuleFor(x => x.Name)
//             .MustAsync(async (name, _) => 
//                 await inputValidationService.CheckAspectValueUniqueness<VehicleEngineType, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleEngineType.Name)))
//             .WithMessage("Engine type with such name already exists!");
//     }
// }