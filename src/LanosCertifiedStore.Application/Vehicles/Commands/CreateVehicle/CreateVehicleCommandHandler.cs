namespace LanosCertifiedStore.Application.Vehicles.Commands.CreateVehicle;

// TODO
// internal sealed class CreateVehicleCommandHandler : ActionVehicleCommandHandlerBase<Guid>,
//     IRequestHandler<CreateVehicleCommand, Result<Guid>>
// {
//     public CreateVehicleCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
//     {
//         PossibleErrors =
//         [
//             new Error("CreateVehicleError", "Saving a new vehicle was not successful!"),
//             new Error("CreateVehicleError", "Error occured during a new vehicle creation!")
//         ];
//     }
//
//     public async Task<Result<Guid>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
//     {
//         var vehicleInstantiationResult = await CreateVehicleInstance(request);
//
//         if (!vehicleInstantiationResult.IsSuccess) 
//             return Result<Guid>.Failure(vehicleInstantiationResult.Error!);
//
//         await AddNewVehicle(vehicleInstantiationResult);
//
//         return await TrySaveChanges(cancellationToken);
//     }
//
//     private async Task AddNewVehicle(Result<Vehicle> vehicleInstantiationResult)
//     {
//         await GetRequiredRepository<Vehicle>().AddNewEntityAsync(vehicleInstantiationResult.Value!);
//
//         ReturnedValue = vehicleInstantiationResult.Value!.Id;
//     }
// }