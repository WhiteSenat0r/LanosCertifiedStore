using FluentValidation;

namespace Application.Commands.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .MinimumLength(20)
            .MaximumLength(3000);

        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThan(0);
        
        RuleFor(x => x.Displacement)
            .NotEmpty()
            .GreaterThan(0);
    }
}