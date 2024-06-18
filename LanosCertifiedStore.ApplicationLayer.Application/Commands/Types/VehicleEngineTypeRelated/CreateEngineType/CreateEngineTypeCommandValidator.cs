using Application.Contracts.RepositoryRelated.Common;
using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using FluentValidation;

namespace Application.Commands.Types.VehicleEngineTypeRelated.CreateEngineType;

// TODO
// internal sealed class CreateEngineTypeCommandValidator : AbstractValidator<CreateEngineTypeCommand>
// {
//     public CreateEngineTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
//     {
//         RuleFor(x => x.Name)
//             .NotEmpty()
//             .MaximumLength(64)
//             .MinimumLength(2)
//             .WithMessage("Name must be greater than 2 characters and less than 64!");
//
//         RuleFor(x => x.Name)
//             .MustAsync(async (name, _) => 
//                 await validationHelper.IsAspectValueUnique<VehicleEngineType, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleEngineType.Name)))
//             .WithMessage("Engine type with such name already exists!");
//     }
// }