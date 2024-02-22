using FluentValidation;

namespace Application.Commands.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
    {
        RuleFor(x => x.CreateVehicleDto.Description)
            .NotEmpty()
            .MinimumLength(20)
            .MaximumLength(3000);

        RuleFor(x => x.CreateVehicleDto.Price)
            .NotEmpty()
            .GreaterThan(0);
    }
}