using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Models.CreateModel;

internal sealed class CreateModelCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<CreateModelCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateModelCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrors = new[]
        {
            new Error("CreateModelError", "Saving a new model was not successful!"),
            new Error("CreateModelError", "Error occured during a new model creation!")
        };
    }

    public async Task<Result<Unit>> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        var vehicleBrand = await _unitOfWork.RetrieveRepository<VehicleBrand>().GetEntityByIdAsync(request.BrandId);

        var newVehicleModel = new VehicleModel(
            vehicleBrand!,
            request.Name,
            availableTypesIds: request.AvailableTypesIds);

        await _unitOfWork.RetrieveRepository<VehicleModel>().AddNewEntityAsync(newVehicleModel);

        return await TrySaveChanges(cancellationToken);
    }
}