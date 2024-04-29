using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Models.UpdateModel;

internal sealed class UpdateModelCommandValidator : AbstractValidator<UpdateModelCommand>
{
    public UpdateModelCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
    {
        RuleFor(x => x.BrandId)
            .MustAsync(async (brandId, _) => 
                await validationHelper.CheckMainAspectPresence<VehicleBrand>(unitOfWork, brandId))
            .WithMessage("Brand with such ID doesn't exists!");

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2)
            .MustAsync(async (name, _) => 
                await validationHelper.IsAspectNameUnique<VehicleModel>(unitOfWork, name))
            .WithMessage("Model with such name already exists! Model name must be unique");

        RuleFor(x => x.TypeId)
            .NotEmpty();
        
        RuleFor(x => x.AvailableBodyTypeIds)
            .NotNull()
            .NotEmpty();
        
        RuleFor(x => x.AvailableEngineTypeIds)
            .NotNull()
            .NotEmpty();
        
        RuleFor(x => x.AvailableTransmissionTypeIds)
            .NotNull()
            .NotEmpty();
        
        RuleFor(x => x.AvailableDrivetrainTypeIds)
            .NotNull()
            .NotEmpty();
        
        RuleFor(x => x.MinimalProductionYear)
            .LessThanOrEqualTo(x => x.MaximumProductionYear)
            .When(x => x.MaximumProductionYear is not null);
        
        RuleFor(x => x.MaximumProductionYear)
            .GreaterThanOrEqualTo(x => x.MinimalProductionYear)
            .When(x => x.MaximumProductionYear is not null);
    }
}