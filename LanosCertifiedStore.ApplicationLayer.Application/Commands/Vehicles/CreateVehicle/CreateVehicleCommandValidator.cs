using FluentValidation;

namespace Application.Commands.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
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