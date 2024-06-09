using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleEngineTypeRelated.CreateEngineType;

internal sealed class CreateEngineTypeCommandHandler 
    : CommandHandlerBase<Unit>, IRequestHandler<CreateEngineTypeCommand, Result<Unit>>
{
    public CreateEngineTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("CreateEngineTypeError", "Saving a new engine type was not successful!"),
            new Error("CreateEngineTypeError", "Error occured during a new engine type creation!")
        ];
    }

    public async Task<Result<Unit>> Handle(CreateEngineTypeCommand request, CancellationToken cancellationToken)
    {
        var newVehicleEngineType = new VehicleEngineType(request.Name);

        await GetRequiredRepository<VehicleEngineType>().AddNewEntityAsync(newVehicleEngineType);

        return await TrySaveChanges(cancellationToken);
    }
}