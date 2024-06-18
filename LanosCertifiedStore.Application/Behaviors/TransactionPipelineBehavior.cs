namespace Application.Behaviors;

// TODO
// public class TransactionPipelineBehavior<TRequest, TResponse>(
//     IUnitOfWork unitOfWork) : IPipelineBehavior<TRequest, TResponse>
//     where TRequest : IRequest<TResponse>
//     where TResponse : Result<Unit>
// {
//     public async Task<TResponse> Handle(
//         TRequest request,
//         RequestHandlerDelegate<TResponse> next,
//         CancellationToken cancellationToken)
//     {
//         await unitOfWork.BeginTransactionAsync();
//
//         var response = await next();
//
//         switch (response.IsSuccess)
//         {
//             case true:
//                 await unitOfWork.CommitTransactionAsync();
//                 break;
//             case false:
//                 await unitOfWork.RollbackTransactionAsync();
//                 break;
//         }
//
//         return response;
//     }
// }