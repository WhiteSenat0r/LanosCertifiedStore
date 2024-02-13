using Application.Core;
using Application.QuerySpecifications.ModelRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Models.CreateModel;

internal sealed class CreateModelCommandHandler(IRepository<VehicleModel> modelRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateModelCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        var existingModel = await modelRepository.GetSingleEntityBySpecificationAsync(
                new ModelByNameQuerySpecification(request.Name));

        if (existingModel is not null)
            return Result<Unit>.Failure("Model with such name already exists!");

        var vehicleModel = new VehicleModel(request.BrandId, request.Name);
        await modelRepository.AddNewEntityAsync(vehicleModel);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to create model!");
    }
}