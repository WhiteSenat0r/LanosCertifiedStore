﻿using LanosCertifiedStore.Application.Shared;
using LanosCertifiedStore.Application.Shared.RequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Behaviors;

public class TransactionPipelineBehavior<TRequest, TResponse>(
    ITransactionService transactionService) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommandRequestBase
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> executedAction,
        CancellationToken cancellationToken)
    {
        await transactionService.BeginTransaction(cancellationToken);

        var response = await executedAction();

        if (!response.IsSuccess)
        {
            await transactionService.RollbackTransaction(cancellationToken);

            return response;
        }

        await transactionService.CommitTransaction(cancellationToken);

        return response;
    }
}