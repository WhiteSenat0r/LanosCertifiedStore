using Application.Helpers;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Models.CreateModel;

internal sealed class CreateModelCommandValidator : AbstractValidator<CreateModelCommand>
{
    public CreateModelCommandValidator(
        ValidationHelper<VehicleModel> modelValidationHelper,
        ValidationHelper<VehicleBrand> brandValidationHelper)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);

        RuleFor(x => x.BrandId)
            .MustAsync(async (brandId, _) => await brandValidationHelper.ExistsById(brandId))
            .WithMessage(
                "Brand with such id doesn't exists!"); // TODO should be replaced with proper exception handling or something idk

        RuleFor(x => x.Name)
            .MustAsync(async (name, _) => await modelValidationHelper.IsNameUniqueAsync(name))
            .WithMessage("Model with such name already exists! Model name must be unique");

        RuleFor(x => x.TypeId)
            .NotEmpty();
    }
}