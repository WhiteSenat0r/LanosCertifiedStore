﻿using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.VehicleBrands.Dtos;

namespace LanosCertifiedStore.Application.VehicleBrands.Queries.SingleVehicleBrandQueryRelated;

public sealed record SingleVehicleBrandQueryRequest(Guid ItemId) : ISingleQueryRequest<SingleVehicleBrandDto>;