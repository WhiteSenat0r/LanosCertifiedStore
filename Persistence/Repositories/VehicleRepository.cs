using Domain.Entities.VehicleRelated.Classes;
using Persistence.Contexts;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleRepository(ApplicationDatabaseContext dbContext)
    : GenericRepository<Vehicle>(dbContext);