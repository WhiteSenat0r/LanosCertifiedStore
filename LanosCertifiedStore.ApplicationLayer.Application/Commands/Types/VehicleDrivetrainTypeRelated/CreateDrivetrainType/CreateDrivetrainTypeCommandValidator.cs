﻿using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using FluentValidation;

namespace Application.Commands.Types.VehicleDrivetrainTypeRelated.CreateDrivetrainType;

internal sealed class CreateDrivetrainTypeCommandValidator : AbstractValidator<CreateDrivetrainTypeCommand>
{
    public CreateDrivetrainTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2)
            .WithMessage("Name must be greater than 2 characters and less than 64!");

        RuleFor(x => x.Name)
            .MustAsync(async (name, _) => 
                await validationHelper.IsAspectNameUnique<VehicleDrivetrainType>(unitOfWork, name))
            .WithMessage("Drivetrain type with such name already exists!");
    }
}