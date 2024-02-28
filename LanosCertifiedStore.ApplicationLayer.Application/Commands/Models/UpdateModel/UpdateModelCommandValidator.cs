using Application.Helpers;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Models.UpdateModel;

internal sealed class UpdateModelCommandValidator : AbstractValidator<UpdateModelCommand>
{
    public UpdateModelCommandValidator(ValidationHelper<VehicleModel> validationHelper)
    {
        RuleFor(x => x.UpdatedName)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);

        RuleFor(x => x.AvailableTypesIds)
            .NotEmpty();

        RuleFor(x => x.BrandId)
            .NotEmpty();

        RuleFor(x => x.UpdatedName)
            .MustAsync(async (name, _) => await validationHelper.IsNameUniqueAsync(name))
            .WithMessage("Model with such name already exists! Model name must be unique");
    }
}