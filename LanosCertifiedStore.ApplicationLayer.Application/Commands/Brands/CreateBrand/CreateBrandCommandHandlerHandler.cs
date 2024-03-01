using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Brands.CreateBrand;

internal sealed class CreateBrandCommandHandlerHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<CreateBrandCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBrandCommandHandlerHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrors = new[]
        {
            new Error("CreateBrandError", "Saving a new brand was not successful!"),
            new Error("CreateBrandError", "Error occured during a new brand creation!")
        };
    }

    public async Task<Result<Unit>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var newBrand = new VehicleBrand(request.Name);
        
        await _unitOfWork.RetrieveRepository<VehicleBrand>().AddNewEntityAsync(newBrand);

        return await TrySaveChanges(cancellationToken);
    }
}