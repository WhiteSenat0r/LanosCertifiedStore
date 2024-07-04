namespace Application.CommandRequests.TypesRelated.VehicleEngineTypeRelated.UpdateEngineType;

// TODO
// internal sealed class UpdateEngineTypeCommandValidator : AbstractValidator<UpdateEngineTypeCommand>
// {
//     public UpdateEngineTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper inputValidationService)
//     {
//         RuleFor(x => x.UpdatedName)
//             .NotEmpty()
//             .MaximumLength(64)
//             .MinimumLength(2)
//             .WithMessage("Name must be greater than 2 characters and less than 64!");
//
//         RuleFor(x => x.UpdatedName)
//             .MustAsync(async (name, _) => 
//                 await inputValidationService.CheckAspectValueUniqueness<VehicleEngineType, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleEngineType.Name)))
//             .WithMessage("Engine type with such name already exists!");
//     }
// }