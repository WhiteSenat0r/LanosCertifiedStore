namespace Application.Commands.Types.VehicleTypeRelated.CreateType;

// TODO
// internal sealed class CreateTypeCommandValidator : AbstractValidator<CreateTypeCommand>
// {
//     public CreateTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
//     {
//         RuleFor(x => x.Name)
//             .NotEmpty()
//             .MaximumLength(64)
//             .MinimumLength(2)
//             .WithMessage("Name must be greater than 2 characters and less than 64!");
//
//         RuleFor(x => x.Name)
//             .MustAsync(async (name, _) => 
//                 await validationHelper.IsAspectValueUnique<VehicleType, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleType.Name)))
//             .WithMessage("Type with such name already exists!");
//     }
// }