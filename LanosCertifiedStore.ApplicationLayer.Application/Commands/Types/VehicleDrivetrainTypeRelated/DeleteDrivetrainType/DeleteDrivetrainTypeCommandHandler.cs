using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Commands.Types.VehicleDrivetrainTypeRelated.DeleteDrivetrainType;

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