﻿using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Vehicles.AddImageToVehicle;

public class AddImageToVehicleCommandValidator : AbstractValidator<AddImageToVehicleCommand>
{
    public AddImageToVehicleCommandValidator()
    {
        RuleFor(x => x.Image)
            .NotEmpty()
            .Must(IsImageFile);

        RuleFor(x => x.Image.Length)
            .GreaterThan(0);

        RuleFor(x => x.VehicleId)
            .NotEmpty();
    }
    
    private bool IsImageFile(IFormFile imageFile) =>
        string.Equals(imageFile.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) ||
        string.Equals(imageFile.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) ||
        string.Equals(imageFile.ContentType, "image/png", StringComparison.OrdinalIgnoreCase);
}