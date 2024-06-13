using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Commands.Types.VehicleDrivetrainTypeRelated.CreateDrivetrainType;

internal sealed class CreateDrivetrainTypeCommandHandler 
    : CommandHandlerBase<Unit>, IRequestHandler<CreateDrivetrainTypeCommand, Result<Unit>>
{
    public CreateDrivetrainTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("CreateDrivetrainTypeError", "Saving a new drivetrain type was not successful!"),
            new Error("CreateDrivetrainTypeError", "Error occured during a new drivetrain type creation!")
        ];
    }

    public async Task<Result<Unit>> Handle(CreateDrivetrainTypeCommand request, CancellationToken cancellationToken)
    {
        var newVehicleDrivetrainType = new VehicleDrivetrainType(request.Name);

        await GetRequiredRepository<VehicleDrivetrainType>().AddNewEntityAsync(newVehicleDrivetrainType);

        return await TrySaveChanges(cancellationToken);
    }
}