using Application.Commands.Vehicles.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Vehicles.UpdateVehicle;

internal sealed class UpdateVehicleCommandHandler : 
    ActionVehicleCommandHandlerBase<Unit>, IRequestHandler<UpdateVehicleCommand, Result<Unit>>
{
    private readonly IMapper _mapper;

    public UpdateVehicleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _mapper = mapper;
        PossibleErrors =
        [
            new Error("UpdateVehicleError", "Saving an updated vehicle was not successful!"),
            new Error("UpdateVehicleError", "Error occured during the vehicle update!")
        ];
    }

    public async Task<Result<Unit>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var updatedEntity = await GetRequiredRepository<Vehicle>().GetEntityByIdAsync(request.Id);

        if (updatedEntity is null) return Result<Unit>.Failure(Error.NotFound);

        var requestVehicleResult = await CreateVehicleInstance(request);

        if (!requestVehicleResult.IsSuccess) return Result<Unit>.Failure(requestVehicleResult.Error!);

        await UpdateVehicle(request, requestVehicleResult.Value!, updatedEntity);

        return await TrySaveChanges(cancellationToken);
    }

    private async Task UpdateVehicle(
        IActionVehicleCommandBase request,
        Vehicle requestVehicleResult,
        Vehicle updatedEntity)
    {
        await TryUpdatePrice(request, updatedEntity);
        
        _mapper.Map(requestVehicleResult, updatedEntity);

        await GetRequiredRepository<Vehicle>().UpdateExistingEntityAsync(updatedEntity);
    }

    private Task TryUpdatePrice(IActionVehicleCommandBase request, Vehicle vehicle) =>
        IsAlteredPriceValue(request, vehicle) 
            ? InitializeNewPrice(request, vehicle) 
            : Task.CompletedTask;

    private async Task InitializeNewPrice(IActionVehicleCommandBase request, Vehicle updatedVehicle)
    {
        var newPrice = new VehiclePrice(updatedVehicle, request.Price);

        await GetRequiredRepository<VehiclePrice>().AddNewEntityAsync(newPrice);
    }

    private bool IsAlteredPriceValue(IActionVehicleCommandBase request, Vehicle updatedVehicle) =>
        !updatedVehicle.Prices.MaxBy(p => p.IssueDate)!.Value.Equals(request.Price);
}