using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Colors.CreateColor;

internal sealed class CreateColorCommandHandler : CommandBase<Unit>, IRequestHandler<CreateColorCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateColorCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrorMessages = 
            ["Saving a new color was not successful!", "Error occured during a new color creation!"];
        PossibleErrorCode = "CreateColorError";
    }

    public async Task<Result<Unit>> Handle(CreateColorCommand request, CancellationToken cancellationToken)
    {
        var newColor = new VehicleColor(request.ColorName, request.HexValue);

        await _unitOfWork.RetrieveRepository<VehicleColor>().AddNewEntityAsync(newColor);

        return await TrySaveChanges(cancellationToken);
    }
}