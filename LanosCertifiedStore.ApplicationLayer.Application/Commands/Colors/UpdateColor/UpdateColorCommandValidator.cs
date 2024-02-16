using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Colors.UpdateColor;

internal sealed class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
{
    public UpdateColorCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.UpdateColorDto.UpdatedName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(64);

        RuleFor(x => x.UpdateColorDto.UpdatedName)
            .MustAsync(async (updatedName, _) =>
            {
                var brands = await unitOfWork.RetrieveRepository<VehicleColor>().GetAllEntitiesAsync();
                return brands.All(x => x.Name != updatedName);
            })
            .WithMessage("Color with such name already exists! Color name must be unique");

    }
}