using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Colors.CreateColor;

internal sealed class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
{
    public CreateColorCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.ColorName)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);

        RuleFor(x => x.ColorName)
            .MustAsync(async (name, _) =>
            {
                var brands = await unitOfWork.RetrieveRepository<VehicleColor>().GetAllEntitiesAsync();
                return brands.All(x => x.Name != name);
            })
            .WithMessage("Color with such name already exists! Color name must be unique");

    }
}