namespace Application.CommandRequests.Types.VehicleBodyTypeRelated.CreateBodyType;

// TODO
// internal sealed class CreateBodyTypeCommandValidator : AbstractValidator<CreateBodyTypeCommand>
// {
//     public CreateBodyTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper inputValidationService)
//     {
//         RuleFor(x => x.Name)
//             .NotEmpty()
//             .MaximumLength(64)
//             .MinimumLength(2)
//             .WithMessage("Name must be greater than 2 characters and less than 64!");
//
//         RuleFor(x => x.Name)
//             .MustAsync(async (name, _) => 
//                 await inputValidationService.CheckAspectValueUniqueness<VehicleBodyType, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleBodyType.Name)))
//             .WithMessage("Body type with such name already exists!");
//     }
// }