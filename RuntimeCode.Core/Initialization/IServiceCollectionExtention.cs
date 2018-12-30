using Microsoft.Extensions.DependencyInjection;

using RuntimeCode.Core.Interfaces.UnitOfWork;
using RuntimeCode.Core.Interfaces.Repositories;
using RuntimeCode.Core.Interfaces.Services;

using RuntimeCode.Core.Implementation.UnitOfWork;
using RuntimeCode.Core.Implementation.Repositories;
using RuntimeCode.Core.Implementation.Services;
using RuntimeCode.Core.Implementation.Entities;

namespace RuntimeCode.Core.Initialization
{
    public static class IServiceCollectionExtention
    {
        public static IServiceCollection AddExtInternalReferences(this IServiceCollection service){
            //todo: Adcionar Injecoes de Dependencia.
            service.AddScoped<IUnitOfWork>( s => new UnitOfWork("mongodb://localhost:27017/dbEnt"));
            service.AddScoped<IEntityTypeRepository<EntityType>, EntityTypeRepository<EntityType>>();
            service.AddScoped<IEntityTypeService<EntityType>, EntityTypeService>();
            return service;
        }
    }
}