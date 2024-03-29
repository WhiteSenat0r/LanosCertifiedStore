﻿using Application.Helpers;
using Domain.Entities.VehicleRelated.Classes.TypesRelated;
using FluentValidation;

namespace Application.Commands.Types.CreateType;

internal sealed class CreateTypeCommandValidator : AbstractValidator<CreateTypeCommand>
{
    public CreateTypeCommandValidator(ValidationHelper<VehicleType> validationHelper)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);

        RuleFor(x => x.Name)
            .MustAsync(async (name, _) => await validationHelper.IsNameUniqueAsync(name))
            .WithMessage("Type with such name already exists! Type name must be unique");
    }
}