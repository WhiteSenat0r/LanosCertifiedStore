using Application.Dtos.ModelDtos;
using Application.Queries.Common.DetailsQueryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Models.ModelDetailsQueryRelated;

public sealed record ModelDetailsQuery(Guid Id) : DetailsQueryBase<VehicleModel>(Id), IRequest<Result<ModelDto>>;