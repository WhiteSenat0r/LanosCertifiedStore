﻿using Application.Helpers;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Colors.UpdateColor;

internal sealed class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
{
    public UpdateColorCommandValidator(ValidationHelper<VehicleColor> validationHelper)
    {
        RuleFor(x => x.UpdatedName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(64);
        
        RuleFor(x => x.UpdatedHexValue)
            .NotEmpty()
            .MaximumLength(12)
            .MinimumLength(2);

        RuleFor(x => x.UpdatedName)
            .MustAsync(async (name, _) => await validationHelper.IsNameUniqueAsync(name))
            .WithMessage("Color with such name already exists! Color name must be unique");
    }
}