using FluentValidation;
using LanosCertifiedStore.Application.Shared.RequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LanosCertifiedStore.Application.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>(
    ILogger<ValidationPipelineBehavior<TRequest, TResponse>> logger,
    IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommandRequestBase
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next();
        }

        var errors = await GetValidationErrors(request, cancellationToken);

        if (!AreErrorsPresent(errors))
        {
            return await next();
        }

        var validationResult = CreateValidationResult<TResponse>(errors);

        logger.LogError("Validation failures have occured: {@ValidationResult}", validationResult);
        return validationResult;
    }

    private static bool AreErrorsPresent(Error[] errors)
    {
        const int emptyValue = 0;

        return errors.Length != emptyValue;
    }

    private async Task<Error[]> GetValidationErrors(TRequest request, CancellationToken cancellationToken)
    {
        var validationResults = await Task.WhenAll(
            validators.Select(validator => validator.ValidateAsync(request, cancellationToken)));

        return validationResults
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure is not null)
            .Select(failure => new Error(
                failure.PropertyName,
                failure.ErrorMessage))
            .Distinct()
            .ToArray();
    }

    private static TResult CreateValidationResult<TResult>(Error[] errors)
        where TResult : Result
    {
        if (typeof(TResult) == typeof(Result))
        {
            return (ValidationResult.WithErrors(errors) as TResult)!;
        }

        const int genericTypeArgumentIndex = 0;

        var validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[genericTypeArgumentIndex])
            .GetMethod(nameof(ValidationResult.WithErrors))!
            .Invoke(null, [errors])!;

        return (TResult)validationResult;
    }
}