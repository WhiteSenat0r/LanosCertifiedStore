using System.Linq.Expressions;
using Application.Shared.ValidationRelated;
using Domain.Contracts.Common;
using Domain.Entities.VehicleRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using FluentValidation;

namespace Application.VehicleModels.Commands.CreateVehicleModelRelated;

// TODO Fix empty IDs
internal sealed class CreateVehicleModelCommandRequestValidator : AbstractValidator<CreateVehicleModelCommandRequest>
{
    public CreateVehicleModelCommandRequestValidator(IValidationHelper validationHelper)
    {
        GetNameValidationRules(validationHelper);
        GetBrandValidationRules(validationHelper);
        GetTypeValidationRules(validationHelper);
        GetBodyTypesValidationRules(validationHelper);
        GetTransmissionTypesValidationRules(validationHelper);
        GetDrivetrainTypesValidationRules(validationHelper);
        GetEngineTypesValidationRules(validationHelper);
        GetProductionYearValidationRules();
    }

    private void GetNameValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, string>> expression = x => x.Name;

        RuleFor(expression)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(64)
            .WithMessage(VehicleModelValidatorMessages.InvalidNameValue);

        RuleFor(expression)
            .MustAsync(async (name, _) =>
            {
                Expression<Func<VehicleModel, bool>> equalityExpression = model => model.Name.Equals(name);

                return await validationHelper.CheckAspectValueUniqueness(name, equalityExpression);
            })
            .WithMessage(VehicleModelValidatorMessages.AlreadyExistingNameValue);
    }

    private void GetBodyTypesValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, IEnumerable<Guid>>> expression =
            x => x.AvailableBodyTypesIds;

        RuleFor(expression)
            .MustAsync(async (_, ids, context, _) =>
                await ExistByIds<VehicleBodyType>(validationHelper, ids, context))
            .WithMessage("Body type with ID {AspectId} does not exist!");
    }

    private void GetEngineTypesValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, IEnumerable<Guid>>> expression =
            x => x.AvailableEngineTypesIds;

        RuleFor(expression)
            .MustAsync(async (_, ids, context, _) =>
                await ExistByIds<VehicleEngineType>(validationHelper, ids, context))
            .WithMessage("Engine type with ID {AspectId} does not exist!");
    }

    private void GetDrivetrainTypesValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, IEnumerable<Guid>>> expression =
            x => x.AvailableDrivetrainTypesIds;

        RuleFor(expression)
            .MustAsync(async (_, ids, context, _) =>
                await ExistByIds<VehicleDrivetrainType>(validationHelper, ids, context))
            .WithMessage("Drivetrain type with ID {AspectId} does not exist!");
    }

    private void GetTransmissionTypesValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, IEnumerable<Guid>>> expression =
            x => x.AvailableTransmissionTypesIds;

        RuleFor(expression)
            .MustAsync(async (_, ids, context, _) =>
                await ExistByIds<VehicleTransmissionType>(validationHelper, ids, context))
            .WithMessage("Transmission type with ID {AspectId} does not exist!");
    }

    private void GetBrandValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, Guid>> expression = x => x.BrandId;

        RuleFor(expression)
            .MustAsync(async (_, id, context, _) =>
                await ExistById<VehicleBrand>(validationHelper, id, context));
    }

    private void GetTypeValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, Guid>> expression = x => x.TypeId;

        RuleFor(expression)
            .MustAsync(async (_, id, context, _) =>
                await ExistById<VehicleType>(validationHelper, id, context))
            .WithMessage("Type with ID {AspectId} does not exist!");
    }

    private void GetProductionYearValidationRules()
    {
        Expression<Func<CreateVehicleModelCommandRequest, int>> minimalProductionYearExpression =
            x => x.MinimalProductionYear;

        Expression<Func<CreateVehicleModelCommandRequest, int>> maximumProductionYearExpression =
            x => x.MaximumProductionYear ?? default;

        RuleFor(minimalProductionYearExpression)
            .GreaterThanOrEqualTo(1900)
            .WithMessage(VehicleModelValidatorMessages.InvalidMinimalProductionYearValue);

        RuleFor(minimalProductionYearExpression)
            .LessThanOrEqualTo(maximumProductionYearExpression)
            .When(p => p.MaximumProductionYear.HasValue)
            .WithMessage(VehicleModelValidatorMessages.TooBigMinimalProductionYearValue);

        RuleFor(maximumProductionYearExpression)
            .GreaterThanOrEqualTo(minimalProductionYearExpression)
            .When(p => p.MaximumProductionYear.HasValue)
            .WithMessage(VehicleModelValidatorMessages.TooSmallMaximumProductionYearValue);
    }

    private static async Task<bool> ExistByIds<TEntity>(
        IValidationHelper validationHelper,
        IEnumerable<Guid> ids,
        ValidationContext<CreateVehicleModelCommandRequest> context)
        where TEntity : class, IIdentifiable<Guid>
    {
        var checkResult = await validationHelper.CheckMainAspectPresence<TEntity>(ids);

        if (!checkResult.IsSuccess)
        {
            context.MessageFormatter.AppendArgument("AspectId", checkResult.Id);
        }

        return checkResult.IsSuccess;
    }

    private static async Task<bool> ExistById<TEntity>(
        IValidationHelper validationHelper,
        Guid id,
        ValidationContext<CreateVehicleModelCommandRequest> context)
        where TEntity : class, IIdentifiable<Guid>
    {
        var checkResult = await validationHelper.CheckMainAspectPresence<TEntity>(id);

        if (!checkResult)
        {
            context.MessageFormatter.AppendArgument("AspectId", id);
        }

        return checkResult;
    }
}