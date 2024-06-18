using Application.Contracts.RepositoryRelated.Common;
using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using FluentValidation;

namespace Application.Commands.Types.VehicleTypeRelated.UpdateType;

// TODO
// internal sealed class UpdateTypeCommandValidator : AbstractValidator<UpdateTypeCommand>
// {
//     public UpdateTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
//     {
//         RuleFor(x => x.UpdatedName)
//             .NotEmpty()
//             .MaximumLength(64)
//             .MinimumLength(2)
//             .WithMessage("Name must be greater than 2 characters and less than 64!");
//
//         RuleFor(x => x.UpdatedName)
//             .MustAsync(async (name, _) => 
//                 await validationHelper.IsAspectValueUnique<VehicleType, string>(
//                     unitOfWork,
//                     name,
//                     nameof(VehicleType.Name)))
//             .WithMessage("Type with such name already exists!");
//     }
// }