namespace Application.CommandRequests.TypesRelated.VehicleBodyTypeRelated.UpdateBodyType;

// TODO
// internal sealed class UpdateBodyTypeCommandValidator : AbstractValidator<UpdateBodyTypeCommand>
// {
//     public UpdateBodyTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper inputValidationService)
//     {
//         RuleFor(x => x.UpdatedName)
//             .NotEmpty()
//             .MaximumLength(64)
//             .MinimumLength(2)
//             .WithMessage("Name must be greater than 2 characters and less than 64!");
//
//         RuleFor(x => x.UpdatedName)
//             .MustAsync(async (name, _) => 
//                 await inputValidationService.CheckAspectValueUniqueness<VehicleBodyType, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleBodyType.Name)))
//             .WithMessage("Body type with such name already exists!");
//     }
// }