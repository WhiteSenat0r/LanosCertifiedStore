namespace Application.Commands.Types.VehicleBodyTypeRelated.CreateBodyType;

// TODO
// internal sealed class CreateBodyTypeCommandValidator : AbstractValidator<CreateBodyTypeCommand>
// {
//     public CreateBodyTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
//     {
//         RuleFor(x => x.Name)
//             .NotEmpty()
//             .MaximumLength(64)
//             .MinimumLength(2)
//             .WithMessage("Name must be greater than 2 characters and less than 64!");
//
//         RuleFor(x => x.Name)
//             .MustAsync(async (name, _) => 
//                 await validationHelper.IsAspectValueUnique<VehicleBodyType, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleBodyType.Name)))
//             .WithMessage("Body type with such name already exists!");
//     }
// }