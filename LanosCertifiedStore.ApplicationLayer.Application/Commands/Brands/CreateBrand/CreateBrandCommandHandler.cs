using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Brands.CreateBrand;

internal sealed class CreateBrandCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<CreateBrandCommand, Result<Unit>>
{

    public CreateBrandCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("CreateBrandError", "Saving a new brand was not successful!"),
            new Error("CreateBrandError", "Error occured during a new brand creation!")
        ];
    }

    public async Task<Result<Unit>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var newBrand = new VehicleBrand(request.Name);
        
        await GetRequiredRepository<VehicleBrand>().AddNewEntityAsync(newBrand);

        return await TrySaveChanges(cancellationToken);
    }
}