using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.CreateType;

internal sealed class CreateTypeCommandHandler : CommandBase<Unit>, IRequestHandler<CreateTypeCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrorMessages = 
            ["Saving a new type was not successful!", "Error occured during a new type creation!"];
        PossibleErrorCode = "CreateTypeError";
    }

    public async Task<Result<Unit>> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
    {
        var newVehicleType = new VehicleType(request.Name);

        await _unitOfWork.RetrieveRepository<VehicleType>().AddNewEntityAsync(newVehicleType);

        return await TrySaveChanges(cancellationToken);
    }
}