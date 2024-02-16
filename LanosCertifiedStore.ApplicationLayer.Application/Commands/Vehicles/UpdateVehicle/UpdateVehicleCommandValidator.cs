using FluentValidation;

namespace Application.Commands.Vehicles.UpdateVehicle;

internal sealed class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
{
    public UpdateVehicleCommandValidator()
    {
        RuleFor(x => x.ActionVehicleDto.Description)
            .NotEmpty()
            .MinimumLength(20)
            .MaximumLength(3000);

        RuleFor(x => x.ActionVehicleDto.Price)
            .NotEmpty()
            .GreaterThan(0);
    }
}