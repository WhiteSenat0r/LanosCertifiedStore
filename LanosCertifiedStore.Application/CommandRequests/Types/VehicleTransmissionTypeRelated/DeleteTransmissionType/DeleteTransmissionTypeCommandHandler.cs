namespace Application.CommandRequests.Types.VehicleTransmissionTypeRelated.DeleteTransmissionType;

// TODO
// internal sealed class DeleteTransmissionTypeCommandHandler : 
//     CommandHandlerBase<Unit>, IRequestHandler<DeleteTransmissionTypeCommand, Result<Unit>>
// {
//     public DeleteTransmissionTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
//     {
//         PossibleErrors =
//         [
//             new Error("DeleteTransmissionTypeError", "Transmission type removal was not successful!"),
//             new Error("DeleteTransmissionTypeError", "Error occured during the transmission type removal!")
//         ];
//     }
//
//     public async Task<Result<Unit>> Handle(DeleteTransmissionTypeCommand request, CancellationToken cancellationToken)
//     {
//         await GetRequiredRepository<VehicleTransmissionType>().RemoveExistingEntityAsync(request.Id);
//
//         return await TrySaveChanges(cancellationToken);
//     }
// }