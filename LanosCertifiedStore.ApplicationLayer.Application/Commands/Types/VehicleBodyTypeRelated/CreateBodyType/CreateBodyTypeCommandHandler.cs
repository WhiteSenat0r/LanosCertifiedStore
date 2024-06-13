using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Commands.Types.VehicleBodyTypeRelated.CreateBodyType;

internal sealed class CreateBodyTypeCommandHandler 
    : CommandHandlerBase<Unit>, IRequestHandler<CreateBodyTypeCommand, Result<Unit>>
{
    public CreateBodyTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("CreateBodyTypeError", "Saving a new body type was not successful!"),
            new Error("CreateBodyTypeError", "Error occured during a new body type creation!")
        ];
    }

    public async Task<Result<Unit>> Handle(CreateBodyTypeCommand request, CancellationToken cancellationToken)
    {
        var newVehicleBodyType = new VehicleBodyType(request.Name);

        await GetRequiredRepository<VehicleBodyType>().AddNewEntityAsync(newVehicleBodyType);

        return await TrySaveChanges(cancellationToken);
    }
}