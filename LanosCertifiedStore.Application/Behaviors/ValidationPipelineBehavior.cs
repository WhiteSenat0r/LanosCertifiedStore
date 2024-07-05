using Application.Shared.ResultRelated;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>(
    ILogger<ValidationPipelineBehavior<TRequest, TResponse>> logger,
    IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
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

    private bool AreErrorsPresent(Error[] errors)
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

    private TResult CreateValidationResult<TResult>(Error[] errors)
        where TResult : Result
    {
        const int genericTypeArgumentIndex = 0;

        var validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[genericTypeArgumentIndex])
            .GetMethod(nameof(ValidationResult<TResult>.WithErrors))!
            .Invoke(null, [errors])!;

        return (TResult)validationResult;
    }
}