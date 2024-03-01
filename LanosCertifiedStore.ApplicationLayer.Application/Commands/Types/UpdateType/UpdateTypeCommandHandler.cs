using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.UpdateType;

internal sealed class UpdateTypeCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<UpdateTypeCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrors = new[]
        {
            new Error("UpdateTypeError", "Saving an updated type was not successful!"),
            new Error("UpdateTypeError", "Error occured during the type update!")
        };
    }

    public async Task<Result<Unit>> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
    {
        var typeRepository = _unitOfWork.RetrieveRepository<VehicleType>();
        var existingType = await typeRepository.GetEntityByIdAsync(request.Id);

        if (existingType is null) return Result<Unit>.Failure(Error.NotFound);

        UpdateType(request.UpdatedName, existingType, typeRepository);

        return await TrySaveChanges(cancellationToken);
    }

    private static void UpdateType(string updatedName, 
        VehicleType existingType, IRepository<VehicleType> typeRepository)
    {
        existingType.Name = updatedName;

        typeRepository.UpdateExistingEntity(existingType);
    }
}