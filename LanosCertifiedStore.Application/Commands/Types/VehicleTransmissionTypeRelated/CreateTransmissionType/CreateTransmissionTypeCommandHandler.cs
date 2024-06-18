namespace Application.Commands.Types.VehicleTransmissionTypeRelated.CreateTransmissionType;

// TODO
// internal sealed class CreateTransmissionTypeCommandHandler 
//     : CommandHandlerBase<Unit>, IRequestHandler<CreateTransmissionTypeCommand, Result<Unit>>
// {
//     public CreateTransmissionTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
//     {
//         PossibleErrors =
//         [
//             new Error("CreateTransmissionTypeError", "Saving a new transmission type was not successful!"),
//             new Error("CreateTransmissionTypeError", "Error occured during a new transmission type creation!")
//         ];
//     }
//
//     public async Task<Result<Unit>> Handle(CreateTransmissionTypeCommand request, CancellationToken cancellationToken)
//     {
//         var newVehicleTransmissionType = new VehicleTransmissionType(request.Name);
//
//         await GetRequiredRepository<VehicleTransmissionType>().AddNewEntityAsync(newVehicleTransmissionType);
//
//         return await TrySaveChanges(cancellationToken);
//     }
// }