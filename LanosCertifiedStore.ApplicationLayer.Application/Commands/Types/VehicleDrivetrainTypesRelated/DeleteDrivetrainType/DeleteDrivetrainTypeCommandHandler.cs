using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleDrivetrainTypesRelated.DeleteDrivetrainType;

internal sealed class DeleteDrivetrainTypeCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<DeleteDrivetrainTypeCommand, Result<Unit>>
{
    public DeleteDrivetrainTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("DeleteDrivetrainTypeError", "Drivetrain type removal was not successful!"),
            new Error("DeleteDrivetrainTypeError", "Error occured during the drivetrain type removal!")
        ];
    }

    public async Task<Result<Unit>> Handle(DeleteDrivetrainTypeCommand request, CancellationToken cancellationToken)
    {
        await GetRequiredRepository<VehicleDrivetrainType>().RemoveExistingEntityAsync(request.Id);

        return await TrySaveChanges(cancellationToken);
    }
}